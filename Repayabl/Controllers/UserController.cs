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
    }
}