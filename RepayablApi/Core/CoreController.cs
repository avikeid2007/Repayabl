using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RepayablApi.Models;
using System;

namespace RepayablApi.Core
{
    public class CoreController : ControllerBase, IDisposable
    {
        protected IMapper mapper;
        protected RepayablDbContext Context { get; set; }
        public CoreController(RepayablDbContext context)
        {
            Context = context;
        }

        public void Dispose()
        {
            Context?.Dispose();
            Context = null;
        }

        protected IMapper GetMapper()
        {
            var baseUrl = Request.Scheme + "://" + Request.Host + Request.PathBase;
            return CoreMapper.GetMapper(baseUrl);
        }
        public T ConvertModels<T, T2>(T2 t2)
        {
            if (mapper == null)
            {
                mapper = GetMapper();
            }
            return mapper.Map<T>(t2);
        }
        public void MapModels<T, T2>(T source, T2 destination)
        {
            if (mapper == null)
            {
                mapper = GetMapper();
            }
            mapper.Map(source, destination);
        }

        public static void MapCreated<T>(T obj, string userName) where T : Auditor
        {
            if (obj != null)
            {
                obj.Created = DateTime.Now;
                obj.CreatedBy = userName;
                obj.IsActive = true;
            }
        }
        public static void MapModified<T>(T obj, string userName) where T : Auditor
        {
            if (obj != null)
            {
                obj.Modified = DateTime.Now;
                obj.ModifiedBy = userName;
            }
        }
    }
}
