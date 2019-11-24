using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repayabl.Core;
using Repayabl.Models;

namespace Repayabl.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : CoreController
    {
        public UserController(RepayablDbContext context) : base(context)
        {

        }
        //[HttpGet]
        //public ActionResult GetMany(string UserName,string Password)
        //{ 

        //}
        [HttpPost]
        public ActionResult<Models.DTOs.User> Login(Models.DTOs.User user)
        {
            if (user != null)
            {
                var authUser = Context.Users.Single(x => x.UserName.Equals(user.UserName) && x.Password.Equals(user.Password));
                if (authUser != null)
                {
                    return Ok();
                }
                return NotFound();
            }
            return BadRequest();
        }
    }
}