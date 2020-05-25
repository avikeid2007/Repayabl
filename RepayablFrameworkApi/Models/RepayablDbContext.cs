using Repayabl.Data;
using System.Data.Entity;

namespace RepayablFrameworkApi.Models
{
    public partial class RepayablDbContext : DbContext
    {
        public RepayablDbContext() : base("RepayblContext")
        {

        }

        public virtual DbSet<FamilyDetail> FamilyDetails { get; set; }
        public virtual DbSet<Property> Properties { get; set; }
        public virtual DbSet<RentTransaction> RentTransactions { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<RoomAllotment> RoomAllotments { get; set; }
        public virtual DbSet<TenantDocument> TenantDocuments { get; set; }
        public virtual DbSet<TenantOutstanding> TenantOutstandings { get; set; }
        public virtual DbSet<Tenant> Tenants { get; set; }
        public virtual DbSet<User> Users { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }
    }
}
