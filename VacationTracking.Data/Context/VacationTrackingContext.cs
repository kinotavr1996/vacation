using Microsoft.EntityFrameworkCore;
using VacationTracking.Data.Configuration;
using VacationTracking.Data.Models;

namespace VacationTracking.Data.Context
{
    public class VacationContext : DbContext
    {  
        public VacationContext(DbContextOptions<VacationContext> options)
          : base(options)
        {  
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.AddConfiguration(new RoleConfiguration());
            modelBuilder.AddConfiguration(new VacationConfiguration());
            modelBuilder.AddConfiguration(new VacationRequestConfiguration());
            modelBuilder.AddConfiguration(new EmployeeConfiguration());

        }
        public DbSet<Employee> Employes { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<VacationPolicy> VacationPolicys { get; set; }
        public DbSet<CompanyHoliday> CompanyHolidays { get; set; }

    }
}
