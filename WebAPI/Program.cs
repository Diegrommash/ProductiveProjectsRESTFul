using Domain.Entities.Identity;
using Identity.Seeds;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading.Tasks;

namespace WebAPI
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            //CreateHostBuilder(args).Build().Run();
            var host = CreateHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope()) 
            {
                var services = scope.ServiceProvider;
                try
                {
                    var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
                    var rolManager = services.GetRequiredService<RoleManager<ApplicationRole>>();

                    await DefaultRoles.SeedAsync(userManager, rolManager);
                    await DefaultBasicUser.SeedAsync(userManager, rolManager);
                    await DefaultUserUser.SeedAsync(userManager, rolManager);
                    await DefaultAdminUser.SeedAsync(userManager, rolManager);
                    await DefaultSuperAdminUser.SeedAsync(userManager, rolManager);
                                                      
                }
                catch (Exception ex)
                {

                    throw;
                }
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
