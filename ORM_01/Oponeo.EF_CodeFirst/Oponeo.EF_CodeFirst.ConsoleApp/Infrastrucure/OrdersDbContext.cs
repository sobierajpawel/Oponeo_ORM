using Microsoft.EntityFrameworkCore;
using Oponeo.EF_CodeFirst.ConsoleApp.Model;
using System.Diagnostics;

namespace Oponeo.EF_CodeFirst.ConsoleApp.Infrastrucure
{
    internal class OrdersDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            dbContextOptionsBuilder
                .UseLazyLoadingProxies()
                .LogTo(message=> Debug.WriteLine(message))
                .UseSqlServer("data source=WS-140P9K3;initial catalog=EF_CodeFirst_Db;user id=sa;password=SQL2019_adm;MultipleActiveResultSets=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ToTable("Products");

            modelBuilder.Entity<OrderLine>().HasKey(x => new { x.OderId, x.LineNumber });
        }

        public override int SaveChanges()
        {
            var entries = ChangeTracker.Entries()
                .Where(x => x.Entity is BaseEntity && (
                    x.State == EntityState.Added || x.State == EntityState.Modified
                ));

            foreach (var entity in entries)
            {
                if (entity.State == EntityState.Added)
                {
                    ((BaseEntity)entity.Entity).CreatedDateTime = DateTime.UtcNow;
                }
                else if (entity.State == EntityState.Modified)
                {
                    ((BaseEntity)entity.Entity).UpdateDateTime = DateTime.UtcNow;
                }
            }

            return base.SaveChanges();
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Product> Products { get; set; }

    }
}
