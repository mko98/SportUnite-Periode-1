using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SportUnite.DAL;

namespace SportUnite.BLL
{
    public class Startup
    {
        public static void bllDIContainer(IServiceCollection services, IConfigurationRoot config)
        {
            var IdentityconnectionString = config["Data:IdentityConnectionString:ConnectionString"];
            services.AddDbContext<AppIdentityDbContext>(options =>
                options.UseSqlServer(IdentityconnectionString));
            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<AppIdentityDbContext>();

            var connectionString = config["Data:SportUnite:ConnectionString"];
            services
                .AddSingleton<IInvoiceRepository, EFInvoiceRepository>()
                .AddSingleton<ISportAttributeRepository, EFSportAttributeRepository>()
                .AddSingleton<ISportComplexRepository, EFSportComplexRepository>()
                .AddSingleton<ISportEventRepository, EFSportEventRepository>()
                .AddSingleton<ISportHallRepository, EFSportHallRepository>()
                .AddSingleton<ISportRepository, EFSportRepository>()
                .AddSingleton<ISportSportAttributeRepository, EFSportSportAttributeRepository>()
                .AddDbContext<AppEventEntityDbContext>(options => options.UseSqlServer(connectionString))
                .BuildServiceProvider();

            //            services
            //                .AddSingleton<ISportsComplexRepository, EFSportsComplexRepository>()
            //                .AddDbContext<EFDatabaseContext>(options =>
            //                    options.UseSqlServer(
            //                        config["Data:SportUnite:ConnectionString"]))
            //                .BuildServiceProvider();

            //            serviceProvider.GetService<ISportsComplexRepository>();
            //            serviceProvider.GetService<EFDatabaseContext>();
        }
    }
}