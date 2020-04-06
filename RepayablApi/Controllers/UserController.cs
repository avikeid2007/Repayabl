using Microsoft.AspNetCore.Mvc;
using RepayablApi.Core;
using RepayablApi.Models;
using System.Linq;
using System.Threading.Tasks;

namespace RepayablApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : CoreController
    {
        public UserController(RepayablDbContext context) : base(context)
        {

        }
        [HttpPost("Login")]
        public ActionResult<Models.DTOs.User> Login(Models.DTOs.User user)
        {
            if (user != null)
            {
                var authUser = Context.Users.Single(x => x.UserName.Equals(user.UserName) && x.Password.Equals(user.Password) && x.IsAuth && x.IsActive);
                if (authUser != null)
                {
                    return Ok(ConvertModels<Models.DTOs.User, User>(authUser));
                }
                return NotFound();
            }
            return BadRequest();
        }
        [HttpPost("Register")]
        public async Task<ActionResult> RegisterAsync(Models.DTOs.User user)
        {
            if (user != null)
            {
                var dbobj = ConvertModels<User, Models.DTOs.User>(user);
                MapCreated(dbobj, "Admin");
                await Context.Users.AddAsync(dbobj);
                await Context.SaveChangesAsync();
                return Ok();
            }
            return BadRequest();
        }
    }
}