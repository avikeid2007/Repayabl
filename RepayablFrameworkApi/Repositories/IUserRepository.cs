using Repayabl.Data;
using System.Collections.Generic;

namespace RepayablFrameworkApi.Repositories
{
    public interface IUserRepository
    {
        List<Repayabl.Data.DTOs.User> GetManyUsers(string userPrincipalName = null, string azureId = null, int? skip = null, int? top = null, bool isActiveOnly = true);
        User SaveUser(Repayabl.Data.DTOs.User user);
    }
}