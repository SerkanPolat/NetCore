using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NetCore.Entities;
using NetCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore.Controllers
{
	public class HomeController : Controller
	{
		private readonly SignInManager<AppUser> _signInManager;
		public HomeController(SignInManager<AppUser> signInManager)
		{
			_signInManager = signInManager;
		}
		public IActionResult Index()
		{
			SetCookie("serkan", "Cookiedeki Bilgi");
			return View();
		}
		public IActionResult Login()
		{
			return View(new UserLoginModel
			{
				userName = "denem",
				RememberMe = true
			});
		}
		[HttpPost]
		public IActionResult Login(UserLoginModel model)
		{
			if (ModelState.IsValid)
			{
				
				Microsoft.AspNetCore.Identity.SignInResult signInResult = _signInManager.PasswordSignInAsync(model.userName, model.password, 
													model.RememberMe,/*Yanlis girislerde kilitleme*/false).Result;
				if (signInResult.Succeeded)
				{
					//Giris yapildiktan sonra Cookie olusturulur.Olusturulan Cookie ayarlari Startup.cs dosyasinda yapildi.
					//Dogrulama istenen her istegin basina [Authorize] yazilarak sadece giris yapmis kisilerin girmesi saglanir.
					return Json("Basarili");
				}
				else
				{
					return Json("Kullanici Bilgileri Hatali");
				}
				
			}

			return Json(model);
		}


		public void SetCookie(string key,string value)
		{
			HttpContext.Response.Cookies.Append(key, value);
		}
		public string GetCookie(string key)
		{
			HttpContext.Request.Cookies.TryGetValue(key, out string value);
			return value;
		}
		public void SetSession(string key,string value)
		{
			HttpContext.Session.SetString(key, value);
		}public void GetSession(string key)
		{
			HttpContext.Session.GetString(key);
		}
	}
}
