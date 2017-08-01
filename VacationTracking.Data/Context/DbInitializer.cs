using Microsoft.EntityFrameworkCore;

namespace VacationTracking.Data.Context
{
    public static class DbInitializer
    {
        public static void Initialize(VacationContext context)
        {
            context.Database.Migrate();
        }
    }
}
