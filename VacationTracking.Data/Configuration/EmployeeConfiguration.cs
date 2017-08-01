using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VacationTracking.Data.Models;

namespace VacationTracking.Data.Configuration
{
    internal class EmployeeConfiguration : DbEntityConfiguration<Employee>
    {
        public override void Configure(EntityTypeBuilder<Employee> entity)
        {
            entity.ToTable("Employee");
            entity.HasKey(c => c.Id);
            entity.Property(c => c.Name).IsRequired();
            entity.Property(c => c.Surname).IsRequired();
            entity.Property(c => c.Email).IsRequired();
            entity.Property(c => c.PasswordClear).IsRequired();
            entity.Property(c => c.StartDate).IsRequired();
            entity.Property(c => c.EndDate).IsRequired();
            entity.HasOne(c => c.Role)
                .WithOne(r => r.Employee)
                .HasForeignKey<Role>(f => f.EmployeeId);
            entity.HasMany(c => c.Requests)
                    .WithOne(f => f.Employee)
                    .HasForeignKey(c => c.EmployeeId);
        }
    }
}
