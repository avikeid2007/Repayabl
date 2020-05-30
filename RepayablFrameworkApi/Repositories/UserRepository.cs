using Repayabl.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace RepayablFrameworkApi.Repositories
{
    public class UserRepository : CoreRepository, IUserRepository
    {
        public List<Repayabl.Data.DTOs.User> GetManyUsers(string userPrincipalName = null, string azureId = null, int? skip = null, int? top = null, bool isActiveOnly = true)
        {
            var query = db.Users.AsQueryable();
            if (isActiveOnly)
            {
                query = query.Where(x => x.IsActive);
            }
            if (string.IsNullOrEmpty(userPrincipalName))
            {
                query = query.Where(x => x.UserPrincipalName == userPrincipalName);
            }
            if (string.IsNullOrEmpty(azureId))
            {
                query = query.Where(x => x.AzureId == azureId);
            }
            if (skip != null)
            {
                query = query.Skip(skip.Value);
            }
            if (top != null)
            {
                query = query.Take(top.Value);
            }
            return query.Select(ConvertModels<Repayabl.Data.DTOs.User, User>).ToList();
        }

        public IHttpActionResult PostUser(Repayabl.Data.DTOs.User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Users.Add(user);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = user.Id }, user);
        }
    }
}