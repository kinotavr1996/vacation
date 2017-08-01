using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VacationTracking.Data.Models;

namespace VacationTracking.Data.Configuration
{
    internal class VacationRequestConfiguration : DbEntityConfiguration<VacationRequest>
    {
        public override void Configure(EntityTypeBuilder<VacationRequest> entity)
        {
            entity.ToTable("VacationRequest");
            entity.HasKey(c => c.Id);
            entity.Property(c => c.Approved).IsRequired();
            entity.Property(c => c.EmployeeId).IsRequired();
            entity.Property(c => c.StartDate).IsRequired();
            entity.Property(c => c.EndDate).IsRequired();
            entity.HasOne(c => c.Employee)
                .WithMany(f => f.Requests)
                .HasForeignKey(c => c.EmployeeId);
        }
    }
}
