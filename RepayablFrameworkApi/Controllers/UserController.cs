using Repayabl.Data.DTOs;
using RepayablFrameworkApi.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace RepayablFrameworkApi.Controllers
{
    public class UserController : ApiController
    {
        IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        // GET: api/Users  
        public List<Repayabl.Data.DTOs.User> GetManyUsers(string userPrincipalName = null, string azureId = null)
        {
            return _userRepository.GetManyUsers(userPrincipalName, azureId);
        }
        //[AllowAnonymous]
        //public async Task<ActionResult> GetThumbnailAsync(Guid id)
        //{
        //    var mid = await Context.ListMediaTypes.FirstOrDefaultAsync(x => x.Text.ToUpper() == "PHOTO");
        //    var media = await Context.InmateMedias.FirstOrDefaultAsync(x => x.InmateId == id && x.MediaType == mid.Id);
        //    if (media == null)
        //    {
        //        return NotFound(null);
        //    }
        //    return File(media.DataBinary, media.DataMimeType);
        //}


        // GET: api/Users/5  
        //[ResponseType(typeof(User))]
        //public IHttpActionResult GetUsers(int id)
        //{
        //    var user = db.Users.Find(id);
        //    if (user == null)
        //    {
        //        return NotFound();
        //    }

        //    return FileContentResult();
        //}

        // PUT: api/Users/5  
        [HttpPut]
        [ResponseType(typeof(void))]
        public IHttpActionResult UpdateUsers(Guid id, User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != user.Id)
            {
                return BadRequest();
            }
            if (!_userRepository.UserExists(id))
            {
                return NotFound();
            }
            _userRepository.UpdateUserAsync(id, user);
            return Ok();
        }

        // POST: api/Users  
        [HttpPost]
        [ResponseType(typeof(User))]
        public async Task<IHttpActionResult> SaveUserAsync(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _userRepository.SaveUserAsync(user);
            return Ok();
        }

        //// DELETE: api/Users/5  
        //[ResponseType(typeof(User))]
        //public IHttpActionResult DeleteUser(int id)
        //{
        //    User user = db.Users.Find(id);
        //    if (user == null)
        //    {
        //        return NotFound();
        //    }

        //    db.Users.Remove(user);
        //    db.SaveChanges();

        //    return Ok(user);
        //}



        //private bool UserExists(Guid id)
        //{
        //    return db.Users.Count(e => e.Id == id) > 0;
        //}
    }
}
