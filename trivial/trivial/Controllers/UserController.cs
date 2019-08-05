using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using trivial.Models;
using trivial.Services.Interfaces;
using Log = Serilog.Log;

namespace trivial.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpOptions("authenticate")]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]UserModel user)
        {
            Log.Debug("UserController.Authenticate -> Start");
            Log.Debug("Params -> user: {@user}", user);

            try
            {
                if (String.IsNullOrEmpty(user.Password))
                    return BadRequest("invalidRequest");

                if (user == null)
                {
                    Log.Warning("Authentication error from {clientIP} using u:{username} p:{password}",
                       HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString(),
                       user?.Name,
                       user?.Password);

                    return BadRequest("invalidLogin");
                }

                _userService.Authenticate(user);


                return Ok(user);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error con la autentificación de {clientIP} utilizando como usuario:{username} y contraseña:{password}: {msg}",
                    HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString(), user?.Name, user?.Password, ex.Message);
                return BadRequest("invalidLogin");
                //return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
            finally
            {
                Log.Debug("UserController.Authenticate -> End");
            }

        }
    }
}