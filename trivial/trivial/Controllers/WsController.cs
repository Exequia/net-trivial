using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using trivial.Services;
//using Log = Serilog.Log;

namespace trivial.Controllers
{
    [EnableCors("AllowAll")]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class WsController : Controller
    {

        //private TestService _testService;

        //public WsController(TestService testService)
        //{
        //    _testService = testService;
        //}

        //GET: Ws
        [HttpGet("test")]
        public ActionResult<string> Test()
        {
            return Ok("esto no es un web socket");
        }


        //[HttpGet("getRootNode")]
        //public ActionResult<ResourcesView> GetRootNode()
        //{
        //    Log.Debug("ResourcesController.GetRootNode -> Start");
        //    try
        //    {
        //        ResourcesView rootView = _resourceService.GetRootNode();
        //        return Ok(rootView);
        //    }
        //    catch (Exception ex)
        //    {
        //        Log.Error(ex, "Error on ResourcesController.GetRootNode: {0}", ex.Message);
        //        return StatusCode((int)HttpStatusCode.InternalServerError);
        //    }
        //    finally
        //    {
        //        Log.Debug("ResourcesController.GetRootNode -> End");
        //    }
        //}

        //// GET: Ws/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        //// GET: Ws/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Ws/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here

        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: Ws/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: Ws/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here

        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: Ws/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: Ws/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        // GET: Ws/test
        //public async Task<ActionResult> TestAsync()
        //{
        //    HttpContext context;

        //    WebSocket webSocket = await context.WebSockets.AcceptWebSocketAsync();
        //    res = await _testService.Echo(context, webSocket);

        //    //https://docs.microsoft.com/es-es/aspnet/core/fundamentals/websockets?view=aspnetcore-2.2
        //    //return Ok("Test is correct");
        //    //if (context.WebSockets.IsWebSocketRequest)
        //    //{
        //    //    WebSocket webSocket = await context.WebSockets.AcceptWebSocketAsync();
        //    //await Echo(context, webSocket);
        //    //}
        //    //else
        //    //{
        //    //    context.Response.StatusCode = 400;
        //    //}
        //}


        //[HttpGet]
        //public async Task SendMessage([FromQueryAttribute]string message)
        //{
        //    await _testService.SendMessageToAllAsync(message);
        //}
    }
}