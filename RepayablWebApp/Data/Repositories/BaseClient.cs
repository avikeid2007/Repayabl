using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepayablWebApp.Data.Repositories
{
    public class BaseClient
    {
        public BaseClient()
        {
            BaseUrl = "http://localhost:62130";
        }
        public string BaseUrl { get; set; }
    }
}
