using AirsoftCore.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AirsoftCore.Persistence
{
    public class AirsoftDbContext : IdentityDbContext<IdentityUser>
    {
        public AirsoftDbContext(DbContextOptions<AirsoftDbContext> options) : base(options)
        {
        }

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductType> ProductTypes { get; set; }
        public virtual DbSet<ProductGroup> ProductGroups { get; set; }
        public virtual DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Brand> Brands { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AirsoftDbContext).Assembly);
        }

        public override int SaveChanges()
        {
            AddTimeStamps();

            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            AddTimeStamps();

            return base.SaveChangesAsync(cancellationToken);
        }

        private void AddTimeStamps()
        {
            var entities = ChangeTracker.Entries().Where(x => x.Entity is BaseEntity && (x.State == EntityState.Added || x.State == EntityState.Modified));

            foreach (var entity in entities)
            {
                var table = (BaseEntity)entity.Entity;

                if (entity.State == EntityState.Added)
                {
                    table.DateCreated = DateTime.UtcNow;
                }

                if (entity.State == EntityState.Modified)
                {
                    table.DateEdited = DateTime.UtcNow;
                }
            }
        }
    }
}
