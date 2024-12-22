using Microsoft.EntityFrameworkCore;
using MiniECommerce.Persistence;

namespace MiniECommerce.API.Extensions
{
    public static class MigrationExtensions
    {
        public static void ApplyMigrations(this IApplicationBuilder app)
        {
            //Proje ayağa kalktığında db'yi ve migrationları çalıştırır. Yani db oluşur ve seed data eklenir.
            using var scope = app.ApplicationServices.CreateScope();
            using var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            context.Database.Migrate();
        }
    }
}
