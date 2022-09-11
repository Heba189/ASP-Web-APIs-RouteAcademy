using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.DAL.Entities.Identity;

namespace Talabat.DAL.Identity
{
    public  class AppIdentityDbContextSeed
    {
        public static async Task SeedUsersAsync(UserManager<AppUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var user = new AppUser()
                {
                    DisplayName = "Heba Abdou",
                    UserName = "HebaAbdou264",
                    Email = "hebaabdou264@gmail.com",
                    PhoneNumber = "0101010122",
                    Address = new Address()
                    {
                        FirstName = "Heba",
                        LastName = "Abdo",
                        Country = "Egypt",
                        City = "Giza",
                        Street = "10 Tahrir st."

                    }
                };
               await userManager.CreateAsync(user ,"Pa$$w0rd");
            }
        }
    }
}
