using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using trivial.Models;
using Log = Serilog.Log;

namespace trivial.Services
{
    public class GameSocketMiddleware
    {
        private static ConcurrentDictionary<string, WebSocket> _sockets = new ConcurrentDictionary<string, WebSocket>();

        private readonly RequestDelegate _next;

        private GameModel _game;


        public GameSocketMiddleware(RequestDelegate next)
        {
            _next = next;
            _game = new GameModel();
        }

        public async Task Invoke(HttpContext context)
        {
            Log.Debug("GameSocketMiddleware.Invoke -> new entry");
            Log.Debug("Params -> context: {@context}", context);

            try
            {
                if (!context.WebSockets.IsWebSocketRequest)
                {
                    await _next.Invoke(context);
                    return;
                }

                CancellationToken ct = context.RequestAborted;
                WebSocket currentSocket = await context.WebSockets.AcceptWebSocketAsync();
                var socketId = Guid.NewGuid().ToString();

                _sockets.TryAdd(socketId, currentSocket);

                while (true)
                {
                    if (ct.IsCancellationRequested)
                    {
                        break;
                    }

                    var response = await ReceiveStringAsync(currentSocket, ct);

                    //if (string.IsNullOrEmpty(response))
                    //{
                    //    if (currentSocket.State != WebSocketState.Open)
                    //    {
                    //        break;
                    //    }

                    //    continue;
                    //}

                    if (!string.IsNullOrEmpty(response))
                        ManageResponse(response);

                    foreach (var socket in _sockets)
                    {
                        if (socket.Value.State != WebSocketState.Open)
                        {
                            continue;
                        }

                        var serializerSettings = new JsonSerializerSettings();
                        serializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                        string gameJson = JsonConvert.SerializeObject(this._game, serializerSettings);
                        await SendStringAsync(socket.Value, gameJson, ct);
                    }
                }

                WebSocket dummy;
                _sockets.TryRemove(socketId, out dummy);

                await currentSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Closing", ct);
                currentSocket.Dispose();

            } catch (Exception ex) {
                Log.Error(ex, "GameSocketMiddleware.Invoke->",  ex.Message);
            }
            finally
            {
                Log.Debug("GameSocketMiddleware.Invoke -> End entry");
            }
        }

        private static Task SendStringAsync(WebSocket socket, string data, CancellationToken ct = default(CancellationToken))
        {
            var buffer = Encoding.UTF8.GetBytes(data);
            var segment = new ArraySegment<byte>(buffer);
            return socket.SendAsync(segment, WebSocketMessageType.Text, true, ct);
        }

        private static async Task<string> ReceiveStringAsync(WebSocket socket, CancellationToken ct = default(CancellationToken))
        {
            var buffer = new ArraySegment<byte>(new byte[8192]);
            using (var ms = new MemoryStream())
            {
                WebSocketReceiveResult result;
                do
                {
                    ct.ThrowIfCancellationRequested();

                    result = await socket.ReceiveAsync(buffer, ct);
                    ms.Write(buffer.Array, buffer.Offset, result.Count);
                }
                while (!result.EndOfMessage);

                ms.Seek(0, SeekOrigin.Begin);
                if (result.MessageType != WebSocketMessageType.Text)
                {
                    return null;
                }

                // Encoding UTF8: https://tools.ietf.org/html/rfc6455#section-5.6
                using (var reader = new StreamReader(ms, Encoding.UTF8))
                {
                    return await reader.ReadToEndAsync();
                }
            }
        }

        private void ManageResponse(string response)
        {
            SocketRequestModel socketRequest = JsonConvert.DeserializeObject<SocketRequestModel>(response);

            switch (socketRequest.Stage)
            {
                case (EnumGameStage.Config):
                    this._game.Stage = socketRequest.Stage;
                    this._game.Options = JsonConvert.DeserializeObject<GameOptionsModel>(socketRequest.Data.ToString());
                    break;

                case (EnumGameStage.Players):
                    this._game.Stage = socketRequest.Stage;
                    PlayerModel player = JsonConvert.DeserializeObject<PlayerModel>(socketRequest.Data.ToString());
                    this._game.Players.Add(player);
                    break;

                case (EnumGameStage.Start):
                    this._game.Stage = socketRequest.Stage;
                    break;
            }
        }
    }
}
