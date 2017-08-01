using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VacationTracking.Data.Models;

namespace VacationTracking.Data.Configuration
{
    internal class RoleConfiguration : DbEntityConfiguration<Role>
    {
        public override void Configure(EntityTypeBuilder<Role> entity)
        {
            entity.ToTable("Role");
            entity.HasKey(c => c.Id);
            entity.Property(c => c.Name).IsRequired();
            entity.HasOne(c => c.Employee)
                .WithOne(x => x.Role)
                .HasForeignKey<Employee>(c => c.RoleId);
		}
	}
}
