using Microsoft.AspNetCore.Mvc;
using Repayabl.Models;

namespace Repayabl.Core
{
    public class CoreController: ControllerBase
    {
        protected RepayablDbContext Context { get; set; }
        public CoreController(RepayablDbContext context)
        {
            Context = context;
        }
    }
}
