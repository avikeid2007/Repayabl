using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RepayablApi.Core;
using RepayablApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepayablApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyController : CoreController
    {

        public PropertyController(RepayablDbContext context) : base(context)
        {

        }

        [HttpGet]
        public ActionResult<IEnumerable<Models.DTOs.Property>> GetProperties(int? UserId, int? skip = null, int? top = null)
        {
            var quary = Context.Properties.Where(x => x.IsActive);
            if (UserId != null)
            {
                quary = quary.Where(x => x.UserId == UserId);
            }
            if (skip != null)
            {
                quary = quary.Skip(skip.Value);
            }
            if (top != null)
            {
                quary = quary.Take(top.Value);
            }
            return quary.AsEnumerable().Select(ConvertModels<Models.DTOs.Property, Property>).ToList();
        }
        [HttpPost]
        public async Task<ActionResult> SavePropertyAsync(Models.DTOs.Property property)
        {
            var dbObj = ConvertModels<Property, Models.DTOs.Property>(property);
            MapCreated(dbObj, User.Identity.Name);
            await Context.Properties.AddAsync(dbObj);
            await Context.SaveChangesAsync();
            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdatePropertyAsync(int? id, Models.DTOs.Property property)
        {
            var dbObj = await Context.Properties.SingleOrDefaultAsync(x => x.Id == id);
            if (dbObj == null) return NotFound();
            MapModels(property, dbObj);
            MapModified(dbObj, "");
            Context.Properties.Update(dbObj);
            await Context.SaveChangesAsync();
            return Ok();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Models.DTOs.Property>> GetPropertyAsync(Guid id)
        {
            var property = await Context.Properties.FindAsync(id);
            if (property == null)
            {
                return NotFound();
            }
            return ConvertModels<Models.DTOs.Property, Property>(property);
        }

        [HttpGet("{propertyid}/Room")]
        public ActionResult<IEnumerable<Models.DTOs.Room>> GetRooms(int? propertyid, int? skip = null, int? top = null)
        {
            var quary = Context.Rooms.Where(x => x.IsActive);
            if (propertyid != null)
            {
                quary = quary.Where(x => x.PropertyId == propertyid);
            }
            if (skip != null)
            {
                quary = quary.Skip(skip.Value);
            }
            if (top != null)
            {
                quary = quary.Take(top.Value);
            }
            return quary.AsEnumerable().Select(ConvertModels<Models.DTOs.Room, Room>).ToList();
        }

        [HttpPost("{propertyid}/Room")]
        public async Task<ActionResult> SaveRoomAsync(int? propertyid, Models.DTOs.Room room)
        {
            if (!await Context.Rooms.AnyAsync(x => x.PropertyId == propertyid))
            {
                return NotFound();
            }
            var dbObj = ConvertModels<Room, Models.DTOs.Room>(room);
            MapCreated(dbObj, User.Identity.Name);
            await Context.Rooms.AddAsync(dbObj);
            await Context.SaveChangesAsync();
            return Ok();
        }
        [HttpPut("{propertyid}/Room/{id}")]
        public async Task<ActionResult> UpdateRoomAsync(int? propertyid, int? id, Models.DTOs.Property property)
        {
            var dbObj = await Context.Rooms.SingleOrDefaultAsync(x => x.Id == id && x.PropertyId == propertyid);
            if (dbObj == null)
            {
                return NotFound();
            }
            MapModels(property, dbObj);
            MapModified(dbObj, "");
            Context.Rooms.Update(dbObj);
            await Context.SaveChangesAsync();
            return Ok();
        }
        [HttpGet("{propertyid}/Room/{id}")]
        public async Task<ActionResult<Models.DTOs.Room>> GetRoomAsync(int? propertyid, int? id)
        {
            var room = await Context.Rooms.SingleOrDefaultAsync(x => x.Id == id && x.PropertyId == propertyid);
            if (room == null)
            {
                return NotFound();
            }
            return ConvertModels<Models.DTOs.Room, Room>(room);
        }
    }
}