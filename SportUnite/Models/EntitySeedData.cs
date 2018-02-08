using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using SportUnite.DAL;
using SportUnite.Domain;
using SportUnite.Domain.Models;


namespace SportUnite.WEBUI.Models
{
    public static class EntitySeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            AppEventEntityDbContext context = app.ApplicationServices.GetRequiredService<AppEventEntityDbContext>();

            SportComplex sportComplex = new SportComplex() { Name = "test complex" };
            SportHall sportHall = new SportHall() { Name = "test hall" };
            Invoice invoice = new Invoice() { Name = "test invoice" };
            Sport sport = new Sport() { Name = "test sports", Description = "a" };
            SportEvent sportEvent = new SportEvent() { Name = "test event", Sport = sport, SportHall = sportHall };
            SportAttribute sportAttribute = new SportAttribute() { Name = "test attribute", Description = "v" };
            SportSportAttribute sportSportAttribute = new SportSportAttribute() { Sport = sport, SportAttribute = sportAttribute };

            sportHall.SportComplex = sportComplex;
            invoice.SportComplex = sportComplex;

            if (!context.SportComplex.Any())
            {
                context.SportComplex.Add(sportComplex);
               
            }

            if (!context.SportHall.Any())
            {
                context.SportHall.Add(sportHall);
                
            }

            if (!context.Invoice.Any())
            {
                context.Invoice.Add(invoice);

            }

            if (!context.Sport.Any())
            {
                context.Sport.Add(sport);
            }

            if (!context.SportEvent.Any())
            {
                context.SportEvent.Add(sportEvent);
            }

            if (!context.SportAttribute.Any())
            {
                context.SportAttribute.Add(sportAttribute);

            }

            if (!context.SportSportAttribute.Any())
            {
                context.SportSportAttribute.Add(sportSportAttribute);
                sport.SportSportAttributes.Add(sportSportAttribute);

            }
            context.SaveChanges();
        }
    }
}