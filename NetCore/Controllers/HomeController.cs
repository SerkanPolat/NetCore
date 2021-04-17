using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore.Controllers
{
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			SetCookie("serkan", "Cookiedeki Bilgi");
			return View();
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
