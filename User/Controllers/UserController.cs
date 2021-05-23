using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace User.Controllers
{
    [Route("api/[controller]/{action}")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public const string SessionKeyUserCount = "_UserCount";

        [HttpGet]
        public IActionResult Random()
        {
            if(HttpContext.Session.GetInt32(SessionKeyUserCount) is  int userCountPerSesson)
            {
                if(userCountPerSesson >= 10)
                {
                    return new JsonResult(new { Message="Try in 10min"});
                   
                }
                else
                {
                    userCountPerSesson++;
                    HttpContext.Session.SetInt32(SessionKeyUserCount, userCountPerSesson);
                    return new JsonResult(new { name = "John Doe", id = userCountPerSesson, url = $"https://i.pravatar.cc/150?img={userCountPerSesson}" });
                }
            }
            else
            {
                HttpContext.Session.SetInt32(SessionKeyUserCount, 1);

                return new JsonResult(new { name = "John Doe", id = 1, url = $"https://i.pravatar.cc/150?img=1" });
            }

        }

    }
}
