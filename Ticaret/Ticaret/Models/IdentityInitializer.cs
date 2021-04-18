using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ticaret.Data.Entities;

namespace Ticaret.Models
{
    public class IdentityInitializer
    {
        public static void CreateAdmin(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            AppUser appUser = new AppUser
            {
                UserName = "yy",
                Name = "yunus",
                SurName = "al"
            };

            if (userManager.FindByNameAsync("yunus").Result==null)
            {
                var IdentityResult=userManager.CreateAsync(appUser,"1").Result;
            }


            if (roleManager.FindByNameAsync("Admin").Result==null)
            {
                IdentityRole ıdentityRole = new IdentityRole
                {
                    Name = "Admin"
                };
                var IdentityResult = roleManager.CreateAsync(ıdentityRole).Result;

               var result= userManager.AddToRoleAsync(appUser, "Admin").Result;
            }

        }
    }
}
