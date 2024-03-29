using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Westwind.AspNetCore.LiveReload;

namespace _port193
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{

			services.AddRazorPages().AddRazorRuntimeCompilation();
			services.AddMvc().AddRazorRuntimeCompilation();

			services.AddControllersWithViews();
			services.AddLiveReload(config =>
			{
				// optional - use config instead
				//config.LiveReloadEnabled = true;
				//config.FolderToMonitor = Path.GetFullname(Path.Combine(Env.ContentRootPath,"..")) ;
			});

			// for ASP.NET Core 3.0 add Runtime Razor Compilation
			// services.AddRazorPages().AddRazorRuntimeCompilation();
			// services.AddMvc().AddRazorRuntimeCompilation();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			//Writing a File Browser Sync can check for to Catch Startup.
			////#if DEBUGapp.UseLiveReload()


			//			try
			//			{
			//				File.WriteAllText("browsersync-update.txt", DateTime.Now.ToString());
			//			}
			//			catch
			//			{
			//				// ignore
			//			}
			////#endif
			///
			// Before any other output generating middleware handlers
			app.UseLiveReload();

			app.UseStaticFiles();
			//app.UseMvcWithDefaultRoute();
			


			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}
			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
			    name: "default",
			    pattern: "{controller=Home}/{action=Index}/{id?}");
			});
		}
	}
}
