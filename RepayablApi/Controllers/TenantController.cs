using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RepayablApi.Core;
using RepayablApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepayablApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TenantController : CoreController
    {

        public TenantController(RepayablDbContext context) : base(context)
        {

        }
        [HttpGet]
        public ActionResult<IEnumerable<Models.DTOs.Tenant>> GetTetants(string firstName, string lastName, int? skip = null, int? top = null)
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
        public async Task<ActionResult> UpdateTenantAsync(int? id, Models.DTOs.Tenant tenant)
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
        public async Task<ActionResult<Models.DTOs.Tenant>> GetTenantAsync(int? id)
        {
            var tenant = await Context.Tenants.FindAsync(id);
            if (tenant == null)
            {
                return NotFound();
            }
            return ConvertModels<Models.DTOs.Tenant, Tenant>(tenant);
        }

        [HttpGet("{tenantid}/Family")]
        public ActionResult<IEnumerable<Models.DTOs.FamilyDetail>> GetFamilyDetails(int? tenantid, int? skip = null, int? top = null)
        {
            var quary = Context.FamilyDetails.Where(x => x.IsActive);
            if (tenantid != null)
            {
                quary = quary.Where(x => x.TenantId == tenantid);
            }
            if (skip != null)
            {
                quary = quary.Skip(skip.Value);
            }
            if (top != null)
            {
                quary = quary.Take(top.Value);
            }
            return quary.AsEnumerable().Select(ConvertModels<Models.DTOs.FamilyDetail, FamilyDetail>).ToList();
        }

        [HttpPost("{tenantid}/Family")]
        public async Task<ActionResult> SaveFamilyDetailAsync(int? tenantid, Models.DTOs.FamilyDetail FamilyDetail)
        {
            if (!await Context.FamilyDetails.AnyAsync(x => x.TenantId == tenantid))
            {
                return NotFound();
            }
            var dbObj = ConvertModels<FamilyDetail, Models.DTOs.FamilyDetail>(FamilyDetail);
            MapCreated(dbObj, User.Identity.Name);
            await Context.FamilyDetails.AddAsync(dbObj);
            await Context.SaveChangesAsync();
            return Ok();
        }
        [HttpPut("{tenantid}/Family/{id}")]
        public async Task<ActionResult> UpdateFamilyAsync(int? tenantid, int? id, Models.DTOs.Property property)
        {
            var dbObj = await Context.FamilyDetails.SingleOrDefaultAsync(x => x.Id == id && x.TenantId == tenantid);
            if (dbObj == null)
            {
                return NotFound();
            }
            MapModels(property, dbObj);
            MapModified(dbObj, "");
            Context.FamilyDetails.Update(dbObj);
            await Context.SaveChangesAsync();
            return Ok();
        }
        [HttpGet("{tenantid}/Family/{id}")]
        public async Task<ActionResult<Models.DTOs.FamilyDetail>> GetTenantAsync(int? tenantid, int? id)
        {
            var FamilyDetail = await Context.FamilyDetails.SingleOrDefaultAsync(x => x.Id == id && x.TenantId == tenantid);
            if (FamilyDetail == null)
            {
                return NotFound();
            }
            return ConvertModels<Models.DTOs.FamilyDetail, FamilyDetail>(FamilyDetail);
        }

        [HttpGet("{tenantid}/Document")]
        public ActionResult<IEnumerable<Models.DTOs.TenantDocument>> GetTenantDocuments(int? tenantid, int? skip = null, int? top = null)
        {
            var quary = Context.TenantDocuments.Where(x => x.IsActive);
            if (tenantid != null)
            {
                quary = quary.Where(x => x.TenantId == tenantid);
            }
            if (skip != null)
            {
                quary = quary.Skip(skip.Value);
            }
            if (top != null)
            {
                quary = quary.Take(top.Value);
            }
            return quary.AsEnumerable().Select(ConvertModels<Models.DTOs.TenantDocument, TenantDocument>).ToList();
        }

        [HttpPost("{tenantid}/Document")]
        public async Task<ActionResult> SaveTenantDocumentAsync(int? tenantid, Models.DTOs.TenantDocument TenantDocument)
        {
            if (!await Context.TenantDocuments.AnyAsync(x => x.TenantId == tenantid))
            {
                return NotFound();
            }
            var dbObj = ConvertModels<TenantDocument, Models.DTOs.TenantDocument>(TenantDocument);
            MapCreated(dbObj, User.Identity.Name);
            await Context.TenantDocuments.AddAsync(dbObj);
            await Context.SaveChangesAsync();
            return Ok();
        }
        [HttpPut("{tenantid}/Document/{id}")]
        public async Task<ActionResult> UpdateTenantDocumentAsync(int? tenantid, int? id, Models.DTOs.Property property)
        {
            var dbObj = await Context.TenantDocuments.SingleOrDefaultAsync(x => x.Id == id && x.TenantId == tenantid);
            if (dbObj == null)
            {
                return NotFound();
            }
            MapModels(property, dbObj);
            MapModified(dbObj, "");
            Context.TenantDocuments.Update(dbObj);
            await Context.SaveChangesAsync();
            return Ok();
        }
        [HttpGet("{tenantid}/Document/{id}")]
        public async Task<ActionResult<Models.DTOs.TenantDocument>> GetTenantDocumentAsync(int? tenantid, int? id)
        {
            var TenantDocument = await Context.TenantDocuments.SingleOrDefaultAsync(x => x.Id == id && x.TenantId == tenantid);
            if (TenantDocument == null)
            {
                return NotFound();
            }
            return ConvertModels<Models.DTOs.TenantDocument, TenantDocument>(TenantDocument);
        }

        [HttpGet("{tenantid}/Outstanding")]
        public ActionResult<IEnumerable<Models.DTOs.TenantOutstanding>> GetTenantOutstandings(int? tenantid, int? skip = null, int? top = null)
        {
            var quary = Context.TenantOutstandings.Where(x => x.IsActive);
            if (tenantid != null)
            {
                quary = quary.Where(x => x.TenantId == tenantid);
            }
            if (skip != null)
            {
                quary = quary.Skip(skip.Value);
            }
            if (top != null)
            {
                quary = quary.Take(top.Value);
            }
            return quary.AsEnumerable().Select(ConvertModels<Models.DTOs.TenantOutstanding, TenantOutstanding>).ToList();
        }

        [HttpPost("{tenantid}/Outstanding")]
        public async Task<ActionResult> SaveTenantOutstandingAsync(int? tenantid, Models.DTOs.TenantOutstanding TenantOutstanding)
        {
            if (!await Context.TenantOutstandings.AnyAsync(x => x.TenantId == tenantid))
            {
                return NotFound();
            }
            var dbObj = ConvertModels<TenantOutstanding, Models.DTOs.TenantOutstanding>(TenantOutstanding);
            MapCreated(dbObj, User.Identity.Name);
            await Context.TenantOutstandings.AddAsync(dbObj);
            await Context.SaveChangesAsync();
            return Ok();
        }
        [HttpPut("{tenantid}/Outstanding/{id}")]
        public async Task<ActionResult> UpdateTenantOutstandingAsync(int? tenantid, int? id, Models.DTOs.Property property)
        {
            var dbObj = await Context.TenantOutstandings.SingleOrDefaultAsync(x => x.Id == id && x.TenantId == tenantid);
            if (dbObj == null)
            {
                return NotFound();
            }
            MapModels(property, dbObj);
            MapModified(dbObj, "");
            Context.TenantOutstandings.Update(dbObj);
            await Context.SaveChangesAsync();
            return Ok();
        }
        [HttpGet("{tenantid}/Outstanding/{id}")]
        public async Task<ActionResult<Models.DTOs.TenantOutstanding>> GetTenantOutstandingAsync(int? tenantid, int? id)
        {
            var TenantOutstanding = await Context.TenantOutstandings.SingleOrDefaultAsync(x => x.Id == id && x.TenantId == tenantid);
            if (TenantOutstanding == null)
            {
                return NotFound();
            }
            return ConvertModels<Models.DTOs.TenantOutstanding, TenantOutstanding>(TenantOutstanding);
        }
    }
}