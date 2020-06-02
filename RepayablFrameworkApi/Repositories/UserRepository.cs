using Repayabl.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

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
            if (!string.IsNullOrEmpty(userPrincipalName))
            {
                query = query.Where(x => x.UserPrincipalName.ToUpper() == userPrincipalName.ToUpper());
            }
            if (!string.IsNullOrEmpty(azureId))
            {
                query = query.Where(x => x.AzureId.ToUpper() == azureId.ToUpper());
            }
            if (skip != null)
            {
                query = query.Skip(skip.Value);
            }
            if (top != null)
            {
                query = query.Take(top.Value);
            }
            return query.ToList().Select(ConvertModels<Repayabl.Data.DTOs.User, User>).ToList();
        }

        public async Task<User> SaveUserAsync(Repayabl.Data.DTOs.User user)
        {
            var dbuser = ConvertModels<User, Repayabl.Data.DTOs.User>(user);
            db.Users.Add(dbuser);
            MapCreated(dbuser, "Avnish");
            await db.SaveChangesAsync();
            return dbuser;
        }
        public async Task UpdateUserAsync(Guid Id, Repayabl.Data.DTOs.User user)
        {
            try
            {
                var dbUser = await db.Users.FindAsync(Id);
                MapModels(user, dbUser);
                db.Entry(dbUser).State = EntityState.Modified;
                await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public bool UserExists(Guid id)
        {
            return db.Users.Count(e => e.Id == id) > 0;
        }
    }
}