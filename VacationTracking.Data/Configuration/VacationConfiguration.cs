using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VacationTracking.Data.Models;

namespace VacationTracking.Data.Configuration
{
    internal class VacationConfiguration : DbEntityConfiguration<VacationPolicy>
    {
        public override void Configure(EntityTypeBuilder<VacationPolicy> entity)
        {
            entity.ToTable("VacationPolicy");
            entity.HasKey(c => c.Id);
            entity.Property(c => c.Days).IsRequired();
            entity.Property(c => c.ServiceYears).IsRequired();
        }

    }
}
