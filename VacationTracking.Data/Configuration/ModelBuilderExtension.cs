using Microsoft.EntityFrameworkCore;


namespace VacationTracking.Data.Configuration
{
    internal static class ModelBuilderExtension

    {
        public static void AddConfiguration<TEntity>(
          this ModelBuilder modelBuilder,
          DbEntityConfiguration<TEntity> entityConfiguration) where TEntity : class
        {
            modelBuilder.Entity<TEntity>(entityConfiguration.Configure);
        }
    }
}
