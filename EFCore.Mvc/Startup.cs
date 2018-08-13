using EFCore.Data.Context;
using EFCore.Mvc.Initializer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EFCore.Mvc
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
			var connectionString = Configuration.GetConnectionString("SqlServerSample");
			services.AddDbContext<SchoolContext>(_ => _.UseSqlServer(connectionString, x => x.MigrationsAssembly("EFCore.SqlSrvContext")), ServiceLifetime.Scoped);
			services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();

				using (var scope = app.ApplicationServices.CreateScope())
				{
					var services = scope.ServiceProvider;
					var context = services.GetRequiredService<SchoolContext>();
					ContextInitializer.Initialize(context);
				}
			}
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();


			app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
