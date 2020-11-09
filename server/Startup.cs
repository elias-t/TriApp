using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using server.Models;
using server.Support;

namespace server
{
    public class Startup
    {
        public static MapperConfiguration mapperConfig;
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;

            var builder = new ConfigurationBuilder()
            .SetBasePath(env.ContentRootPath)
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            ConfigurationBuilder = builder.Build();
        }

        public IConfiguration Configuration { get; }

        public IConfigurationRoot ConfigurationBuilder { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            

            //DB Connection
            var connection = ConfigurationBuilder.GetSection("TriSettings").GetSection("DbConnectionHome").Value;
            services.AddDbContext<TriathlonContext>(options => options.UseSqlServer(connection));

            //DI - Add repository
            services.AddScoped<ITriathlonRepository, TriathlonRepository>();

            //Automapper
            mapperConfig = new MapperConfiguration(
                cfg => cfg.AddProfile(new BasicMapperProfile()));
            //mapperConfig.AssertConfigurationIsValid();
            services.AddSingleton<IMapper>(sp => mapperConfig.CreateMapper());

            //Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "My First API", Version = "v1" });
            });

            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                                  builder =>
                                  {
                                      //builder.WithOrigins("http://localhost:4200", "http://localhost:8080")
                                      builder.AllowAnyOrigin()
                                      .AllowAnyHeader()
                                      .AllowAnyMethod();
                                  });
            });
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(MyAllowSpecificOrigins);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My First API");
            });

            
        }
    }
}
