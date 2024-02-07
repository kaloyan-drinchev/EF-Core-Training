using Microsoft.EntityFrameworkCore;

namespace ContosoPizza.Data;

public static class Extensions
{
    public static void CreateDbIfNotExists(this IHost host)
    {
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                PizzaContext context = services.GetRequiredService<PizzaContext>();
                context.Database.EnsureCreated();
                context.Database.Migrate();
                DbInitializer.Initialize(context);
            }
        }
    }
}