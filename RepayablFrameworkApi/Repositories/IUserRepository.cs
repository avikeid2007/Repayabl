using Repayabl.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RepayablFrameworkApi.Repositories
{
    public interface IUserRepository
    {
        List<Repayabl.Data.DTOs.User> GetManyUsers(string userPrincipalName = null, string azureId = null, int? skip = null, int? top = null, bool isActiveOnly = true);
        Task<User> SaveUserAsync(Repayabl.Data.DTOs.User user);
        Task UpdateUserAsync(Guid Id, Repayabl.Data.DTOs.User user);
        bool UserExists(Guid id);
    }
}