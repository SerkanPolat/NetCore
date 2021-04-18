using Microsoft.AspNetCore.Identity;
using NetCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore
{
	public class IdentityInitializer
	{
		public static void CreateAdmin(UserManager<AppUser> userManager,
			RoleManager<IdentityRole> roleManager)
		{
			AppUser appUser = new AppUser
			{
				Name = "Serkan",
				Surname = "Polat",
				UserName = "SerkanP"
			};
			if (userManager.FindByNameAsync("Serkan").Result == null)
			{
				var identityResult = userManager.CreateAsync(appUser,"A").Result;
			}
			if (roleManager.FindByNameAsync("Admin").Result == null)
			{
				IdentityRole role = new IdentityRole
				{
					Name = "Admin"
				};
				var identityResult = roleManager.CreateAsync(role).Result;
				var s = userManager.AddToRoleAsync(appUser, role.Name).Result;
			}
		}
	}
}
