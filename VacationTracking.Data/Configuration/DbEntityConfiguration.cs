using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VacationTracking.Data.Configuration
{
    internal abstract class DbEntityConfiguration<TEntity> where TEntity : class
    {
        public abstract void Configure(EntityTypeBuilder<TEntity> entity);
    }
}
