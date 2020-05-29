using AutoMapper;
using Repayabl.Data;
using RepayablFrameworkApi.Models;
using System;

namespace RepayablFrameworkApi.Repositories
{
    public class CoreRepository
    {
        protected IMapper mapper;
        protected RepayablDbContext db = new RepayablDbContext();

        protected IMapper GetMapper()
        {
            return RepayablMapper.GetMapper();
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

        public static void MapCreated<T>(T obj, string userName = null) where T : Auditor
        {
            if (obj != null)
            {
                obj.Created = DateTime.Now;
                obj.CreatedBy = userName;
                obj.IsActive = true;
            }
        }

        public static void MapModified<T>(T obj, string userName = null) where T : Auditor
        {
            if (obj != null)
            {
                obj.Modified = DateTime.Now;
                obj.ModifiedBy = userName;
            }
        }
    }
}