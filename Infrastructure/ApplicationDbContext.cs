using Application.Interfaces;
using Core.Contracts;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class ApplicationDbContext : DbContext,IApplicationDbContext
    {
        public string TenantId { get; set; }
        private readonly ITenantService _tenantService;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options , ITenantService tenantService) :base(options)
        {
            //ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            _tenantService = tenantService;
            TenantId = _tenantService.GetTenant()?.TID;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>().HasQueryFilter(a => a.TenantId == TenantId);
            modelBuilder.Entity<Category>().HasQueryFilter(a => a.TenantId == TenantId);
            modelBuilder.Entity<Department>().HasQueryFilter(a => a.TenantId == TenantId);
            modelBuilder.Entity<Employee>().HasQueryFilter(a => a.TenantId == TenantId);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var tenantConnectionString = _tenantService.GetConnectionString();
            if (!string.IsNullOrEmpty(tenantConnectionString))
            {
                var DBProvider = _tenantService.GetDatabaseProvider();
                if (DBProvider.ToLower() == "mssql")
                {
                    optionsBuilder.UseSqlServer(_tenantService.GetConnectionString());
                }
            }
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var item in ChangeTracker.Entries<IMustHaveTenant>().AsEnumerable())
            {
                switch (item.State)
                {
                    case EntityState.Added:
                    case EntityState.Modified:
                        item.Entity.TenantId = TenantId;
                        break;
                }

            }
            foreach (var item in ChangeTracker.Entries<BaseEntity>().AsEnumerable())
            {
                switch (item.State)
                {
                    case EntityState.Added:
                        item.Entity.CreatedAt = DateTime.Now;
                        item.Entity.UpdatedAt = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        item.Entity.UpdatedAt = DateTime.Now;
                        break;

                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }


        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}
