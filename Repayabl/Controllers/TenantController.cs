using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repayabl.Core;
using Repayabl.Models;

namespace Repayabl.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TenantController : CoreController
    {

        public TenantController(RepayablDbContext context) : base(context)
        {

        }
        [HttpGet]
        public ActionResult<IEnumerable<Models.DTOs.Tenant>> GetTetants(string firstName, string lastName,  int? skip = null, int? top = null)
        {
            var quary = Context.Tenants.Where(x => x.IsActive);
            if (!string.IsNullOrEmpty(firstName))
            {
                quary = quary.Where(x => x.FirstName == firstName);
            }
            if (!string.IsNullOrEmpty(lastName))
            {
                quary = quary.Where(x => x.FirstName == lastName);
            }
            if (skip != null)
            {
                quary = quary.Skip(skip.Value);
            }
            if (top != null)
            {
                quary = quary.Take(top.Value);
            }
            return quary.AsEnumerable().Select(ConvertModels<Models.DTOs.Tenant, Tenant>).ToList();
        }
        [HttpPost]
        public async Task<ActionResult> SaveTenantAsync(Models.DTOs.Tenant tenant)
        {
            var dbObj = ConvertModels<Tenant, Models.DTOs.Tenant>(tenant);
            MapCreated(dbObj, User.Identity.Name);
            await Context.Tenants.AddAsync(dbObj);
            await Context.SaveChangesAsync();
            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateTenantAsync(Guid id, Models.DTOs.Tenant tenant)
        {
            var dbObj = await Context.Tenants.SingleOrDefaultAsync(x => x.Id == id);
            if (dbObj == null) return NotFound();
            MapModels(tenant, dbObj);
            MapModified(dbObj, "");
            Context.Tenants.Update(dbObj);
            await Context.SaveChangesAsync();
            return Ok();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Models.DTOs.Tenant>> GetTenantAsync(Guid id)
        {
            var tenant = await Context.Tenants.FindAsync(id);
            if (tenant == null)
            {
                return NotFound();
            }
            return ConvertModels<Models.DTOs.Tenant, Tenant>(tenant);
        }


    }
}