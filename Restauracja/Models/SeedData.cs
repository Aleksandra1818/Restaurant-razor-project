using Microsoft.EntityFrameworkCore;
using Restauracja.Data;

namespace Restauracja.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new RestauracjaContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<RestauracjaContext>>()))
            {
                if (context == null || context.Food == null)
                {
                    throw new ArgumentNullException("Null RestauracjaContext");
                }

                if (context.Food.Any())
                {
                    return;
                }

                context.Food.AddRange(
                    new Food
                    {
                        Name = "Omlet na słodko",
                        Description = "Puszysty omlet podawany ze świeżymi owocami, jogurtem naturalnym i miodem",
                        Price = 12.99M,
                        IsVegetarian = true
                    },

                    new Food
                    {
                        Name = "Omlet na słono",
                        Description = "Omlet podawany ze smażonym bekonem, cebulką, papryką i serem",
                        Price = 14.99M
                    },

                    new Food
                    {
                        Name = "Jabłkowe specjalne racuszki",
                        Description = "Racuszki na mące kukurydzianej, z mlekiem owsianym i jabłkami",
                        Price = 10.00M,
                        IsVegetarian = true,
                        IsVegan = true,
                        IsLactoseFree = true,
                        IsGlutenFree = true
                    },

                    new Food
                    {
                        Name = "Racuszki jak u babci",
                        Description = "Puszysty racuszki z jabłkami, podawane z konfiturą z wiśni",
                        Price = 7.99M,
                        IsVegetarian = true
                    },

                    new Food
                    {
                        Name = "Pożywna owsianka",
                        Description = "Owsianka z jogurtem (możliwość wyboru jogurtu bez laktozy), orzechami, świeżymi owocami i miodem",
                        Price = 14.99M,
                        IsVegetarian = true,
                        IsLactoseFree = true
                    },

                    new Food
                    {
                        Name = "Włoska kanpaka",
                        Description = "Chrupiaca bagietka z mozarellą, szynką parmeńską, pesto bazyliowym i pomidorkami koktajlowymi skrapiana oliwą",
                        Price = 15.99M,
                    },

                    new Food
                    {
                        Name = "Polska kanapka",
                        Description = "Chrupiąca bagietka z sałatą, ogókami, pomidorami, szynką, majonem i serem",
                        Price = 15.99M,
                    },

                    new Food
                    {
                        Name = "Ale warzywo! kanapka",
                        Description = "Chrupiąca bagietka z kotletem z buraka, sałatą, papryką, cebulą, ogórkiem, polana sosem musztardowo-majonezowym",
                        Price = 15.99M,
                        IsVegetarian = true
                    },

                    new Food
                    {
                        Name = "Klasyczna jajecznica",
                        Description = "Puszytsa jajecznica na maśle podawana z grzankami i sałatką ze świeżych warzyw. Możliwośc wyboru chlebu bezglutenowego",
                        Price = 10.99M,
                        IsVegetarian = true,
                        IsGlutenFree = true
                    },

                    new Food
                    {
                        Name = "Jajecznica na wypasie",
                        Description = "Jajecznica smażona na maśle, z bekem, kiełbasą, szynką, serem, cebulą, papryką, chilli, podawana z grzankami i sałatką ze świeżych warzyw.Możliwośc wyboru chlebu bezglutenowego",
                        Price = 7.99M,
                        IsGlutenFree = true
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
