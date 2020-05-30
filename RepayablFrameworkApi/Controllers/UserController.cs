using Repayabl.Data.DTOs;
using RepayablFrameworkApi.Repositories;
using System.Collections.Generic;

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

        //// PUT: api/Users/5  
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutUsers(Guid id, User user)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != user.Id)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(user).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!UserExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        // POST: api/Users  
        [ResponseType(typeof(User))]
        public IHttpActionResult PostUser(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Users.Add(user);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = user.Id }, user);
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

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        //private bool UserExists(Guid id)
        //{
        //    return db.Users.Count(e => e.Id == id) > 0;
        //}
    }
}
