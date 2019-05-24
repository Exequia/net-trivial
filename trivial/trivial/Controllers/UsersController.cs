using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using trivial.Models;
using trivial.Services.interfaces;

namespace trivial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        //    [AllowAnonymous]
        //    [HttpOptions("authenticate")]
        //    [HttpPost("authenticate")]
        //    public IActionResult Authenticate([FromBody]User user)
        //    {
        //        try
        //        {
        //            var user = _userService.Authenticate(userParam.Username, userParam.Password);

        //            // TODO : Better error handling
        //            if (user == null)
        //            {
        //                Log.Warning("Authentication error from {clientIP} using u:{username} p:{password}",
        //                   HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString(),
        //                   userParam?.Username,
        //                   userParam?.Password);

        //                return BadRequest("invalidLogin");
        //            }

        //            return Ok(user);
        //        }
        //        catch (Exception ex)
        //        {
        //            Log.Error(ex, "Error con la autentificación de {clientIP} utilizando como usuario:{username} y contraseña:{password}: {msg}",
        //                HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString(), userParam?.Username, userParam?.Password, ex.Message);
        //            return BadRequest("invalidLogin");
        //        }

        //    }
        //}
    }
}
