using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using NetCore.Context;
using NetCore.Entities;
using NetCore.Interfaces;
using NetCore.Repositories;
using NetCore.Repositories.Dapper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore
{
	public class Startup
	{
		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
		public void ConfigureServices(IServiceCollection services)
		{
			////Nesne sadece bir kere olusturulur
			//services.AddSingleton();
			////Herkese Her istekte nesne yaratilir
			//services.AddTransient();
			//Cagiran kisiye sadece bir tane nesne yaratilir. Her Sessiona 
			services.AddScoped<IKategoriRepository, KategoriRepository>();
			services.AddScoped<IUrunRepository, DpUrunRepository>();
			services.AddScoped<IUrunKategoriRepository, UrunKategoriRepository>();
			services.AddControllersWithViews().AddRazorRuntimeCompilation();
			//Session Kullanimi Uygulamaya Ekleniyor.
			services.AddSession();
			services.AddDbContext<YoutubeContext>();
			services.AddIdentity<AppUser, IdentityRole>(opt =>
			{
				opt.Password.RequireDigit = false;
				opt.Password.RequireLowercase = false;
				opt.Password.RequireNonAlphanumeric = false;
				opt.Password.RequiredLength = 1;
				opt.Password.RequireUppercase = false;
			})
				.AddEntityFrameworkStores<YoutubeContext>();

			
			services.AddAuthentication();
			services.ConfigureApplicationCookie(opt =>
			{
				//Kullanici giris yapmamis ise yonlendirilecek URL
				opt.LoginPath = new PathString("/Home/Login");
				//Cookie ye isim veriliyor.
				opt.Cookie.Name = "NetCore";
				//Cookie javascript ile okunabilsin mi ?
				//True olursa veri cekilemez default False
				opt.Cookie.HttpOnly = true;
				//Domain ve Alt Domainlerin Cookielere Erisim ayari yapiliyor.
				opt.Cookie.SameSite = SameSiteMode.Strict;
				//Kullanici Bilgisayarinda ne kadar tutulacagi belirleniyor.
				opt.ExpireTimeSpan = TimeSpan.FromMinutes(15);


			});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env,
			UserManager<AppUser> userManager,RoleManager<IdentityRole> roleManager)
		{


			IdentityInitializer.CreateAdmin(userManager, roleManager);
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			//Session Middleware Kullaniliyor. Session Kullanimi aciliyor.
			app.UseSession();
			app.UseRouting();
			//Kullanici Giris yapmis mi kontrolu
			app.UseAuthentication();
			//Yetki varmi kontrolu
			app.UseAuthorization();


			//Statik dosyalar erisime aciliyor . Bootstrap vb.
			app.UseStaticFiles(new StaticFileOptions
			{
				//Node Modules klasoru /content olarak erisime aciliyor.
				//cshtml de /node_modules /content olarak degistirmelidir. 
				FileProvider = new PhysicalFileProvider(Path.Combine
				(Directory.GetCurrentDirectory(),"node_modules")),
				RequestPath = "/content"
			});
			////Tek Kullanilir ise dizindeki wwwroot klasoru erisime acilir.wwwroot klasoru yok ise olusturulabilir
			////Bu sayede wwwroot icerisinde Add>Client-Side Library secenegi ile Libman Kullanilarak paketler yuklenebilir.
			////Libmanda paket isimlerdirmeleri farklidir internetten bakilmasi gerekebilir bootstrap == twitter-boostrap
			//app.UseStaticFiles();

			//localhost/serkan istegi Home controller index actiona yonlendirildi.
			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
					name: "DenemeRoute",
					//localhost/serkan
					pattern: "serkan",
					defaults: new { Controller = "Home", Action = "Index" }
					);
			});
			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(name: "areas", pattern: "{area}/{controller=Home}/{Action=Index}/{id?}");
				endpoints.MapControllerRoute(name: "default", pattern: "{Controller=Home}/{Action=Index}");
			});
			
		}
	}
}
