using Microsoft.EntityFrameworkCore;

namespace RepayablApi.Models
{
    public partial class RepayablDbContext : DbContext
    {
        public RepayablDbContext(DbContextOptions<RepayablDbContext> options)
            : base(options)
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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FamilyDetail>(entity =>
            {
                entity.HasIndex(e => e.TenantId);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.City).IsUnicode(false);

                entity.Property(e => e.Country).IsUnicode(false);

                entity.Property(e => e.FirstName).IsUnicode(false);

                entity.Property(e => e.Gender).IsUnicode(false);

                entity.Property(e => e.LastName).IsUnicode(false);

                entity.Property(e => e.Relationship).IsUnicode(false);

                entity.Property(e => e.State).IsUnicode(false);

                entity.HasOne(d => d.Tenant)
                    .WithMany(p => p.FamilyDetails)
                    .HasForeignKey(d => d.TenantId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_79");
            });

            modelBuilder.Entity<Property>(entity =>
            {
                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.City).IsUnicode(false);

                entity.Property(e => e.Country).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);

                entity.Property(e => e.Remarks).IsUnicode(false);

                entity.Property(e => e.State).IsUnicode(false);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Properties)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_137");
            });

            modelBuilder.Entity<RentTransaction>(entity =>
            {
                entity.HasIndex(e => e.PaidBy)
                    .HasName("fkIdx_100");

                entity.HasIndex(e => e.RoomId)
                    .HasName("fkIdx_103");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.BillNo).IsUnicode(false);



                entity.HasOne(d => d.PaidByNavigation)
                    .WithMany(p => p.RentTransactions)
                    .HasForeignKey(d => d.PaidBy)
                    .HasConstraintName("FK_100");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.RentTransactions)
                    .HasForeignKey(d => d.RoomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_103");
            });
            modelBuilder.Entity<RoomAllotment>(entity =>
            {
                entity.HasIndex(e => e.TenantId);
                entity.HasIndex(e => e.RoomId);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Room>(entity =>
        {
            entity.HasIndex(e => e.CurrentTenantId);

            entity.HasIndex(e => e.LastPaidBillId)
                .HasName("fkIdx_134");

            entity.HasIndex(e => e.PropertyId);

            entity.Property(e => e.Id).ValueGeneratedOnAdd();



            entity.Property(e => e.RoomNo).IsUnicode(false);

            entity.HasOne(d => d.CurrentTenant)
                .WithMany(p => p.Rooms)
                .HasForeignKey(d => d.CurrentTenantId)
                .HasConstraintName("FK_52");

            entity.HasOne(d => d.Property)
                .WithMany(p => p.Rooms)
                .HasForeignKey(d => d.PropertyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_37");
        });

            modelBuilder.Entity<TenantDocument>(entity =>
            {
                entity.HasIndex(e => e.TenantId);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();



                entity.Property(e => e.FileExtension).IsUnicode(false);

                entity.Property(e => e.MimeType).IsUnicode(false);

                entity.Property(e => e.Title).IsUnicode(false);

                entity.Property(e => e.Type).IsUnicode(false);

                entity.HasOne(d => d.Tenant)
                    .WithMany(p => p.TenantDocuments)
                    .HasForeignKey(d => d.TenantId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_117");
            });

            modelBuilder.Entity<TenantOutstanding>(entity =>
            {
                entity.HasIndex(e => e.TenantId)
                    .HasName("fkIdx_144");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();



                entity.HasOne(d => d.Tenant)
                    .WithMany(p => p.TenantOutstandings)
                    .HasForeignKey(d => d.TenantId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_144");
            });

            modelBuilder.Entity<Tenant>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.City).IsUnicode(false);

                entity.Property(e => e.Country).IsUnicode(false);

                entity.Property(e => e.FirstName).IsUnicode(false);

                entity.Property(e => e.Gender).IsUnicode(false);

                entity.Property(e => e.LastName).IsUnicode(false);

                entity.Property(e => e.State).IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();



                entity.Property(e => e.Password).IsUnicode(false);

                entity.Property(e => e.UserName).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
