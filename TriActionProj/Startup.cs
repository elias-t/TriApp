using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TriCalcAngular.Models;
using TriCalcAngular.Support;

namespace TestAngularProj
{
    public class Startup
    {
        public static MapperConfiguration mapperConfig;

        public IConfiguration Configuration { get; private set; }
        public IConfigurationRoot ConfigurationBuilder { get; set; }

        private static readonly string AngularPath = @"\ClientApp\dist\ClientApp\";

        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            Configuration = configuration;

            var builder = new ConfigurationBuilder()
            .SetBasePath(env.ContentRootPath+ AngularPath)
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            ConfigurationBuilder = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist/ClientApp";
            });

            //HOME
            //var connection = @"Server=DESKTOP-4NUD22C;Database=TriathlonResults;Trusted_Connection=True;ConnectRetryCount=0";
            //WORK 
            //var connection = @"Server=SAU019855\SCOTCOURTSDB;Database=TriathlonResults;Trusted_Connection=True;ConnectRetryCount=0";
            var connection = ConfigurationBuilder.GetSection("TriSettings").GetSection("DbConnectionWork").Value;
            services.AddDbContext<TriathlonContext>(options => options.UseSqlServer(connection));

            //DI - Add repository
            services.AddScoped<ITriathlonRepository, TriathlonRepository>();

            //Automapper
            mapperConfig = new MapperConfiguration(
                cfg => cfg.AddProfile(new BasicMapperProfile()));
            //mapperConfig.AssertConfigurationIsValid();

            //Create singleton mapper
            services.AddSingleton<IMapper>(sp => mapperConfig.CreateMapper());

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    //spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }
    }
}
