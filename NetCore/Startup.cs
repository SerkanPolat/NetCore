using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
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
			services.AddControllersWithViews();
			//Session Kullanimi Uygulamaya Ekleniyor.
			services.AddSession();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			//Session Middleware Kullaniliyor. Session Kullanimi aciliyor.
			app.UseSession();
			app.UseRouting();
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
				endpoints.MapControllerRoute(name: "default", pattern: "{Controller=Home}/{Action=Index}");
			});
		}
	}
}
