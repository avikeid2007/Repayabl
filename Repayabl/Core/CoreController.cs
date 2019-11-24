using Microsoft.AspNetCore.Mvc;
using Repayabl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
