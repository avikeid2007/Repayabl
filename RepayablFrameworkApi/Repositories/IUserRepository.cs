using Repayabl.Data.DTOs;
using System.Collections.Generic;

namespace RepayablFrameworkApi.Repositories
{
    public interface IUserRepository
    {
        List<User> GetManyUsers(string userPrincipalName = null, string azureId = null, int? skip = null, int? top = null, bool isActiveOnly = true);
    }
}