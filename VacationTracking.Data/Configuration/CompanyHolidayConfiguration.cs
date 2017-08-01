using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VacationTracking.Data.Models;

namespace VacationTracking.Data.Configuration
{
    internal class CompanyHolidayConfiguration : DbEntityConfiguration<CompanyHoliday>
    {
        public override void Configure(EntityTypeBuilder<CompanyHoliday> entity)
        {
            entity.ToTable("CompanyHoliday");
            entity.HasKey(c => c.Id);
            entity.Property(c => c.HolidayDate).IsRequired();
            entity.Property(c => c.Name).IsRequired();
		}
	}
}
