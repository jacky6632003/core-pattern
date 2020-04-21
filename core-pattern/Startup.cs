using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using core_pattern.Infrastructure.Dependency;
using core_pattern.Infrastructure.Mapping;
using core_pattern.Repository.Helper;
using core_pattern.Service.Infrastructure.Mapping;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using core_pattern.Infrastructure.Filter;

namespace core_pattern
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        private string WLDOonnection { get; set; }

        private string MySQLConnection { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<IISServerOptions>(options =>
            {
                options.AutomaticAuthentication = false;
            });

            services.Configure<IISOptions>(options =>
            {
                options.ForwardClientCertificate = false;
            });
            // AutoMapper Auto Mapper Configurations
            //var mappingConfig = new MapperConfiguration(mc =>
            //{
            //    mc.AddProfile(new ControllerMappingProfile());
            //    mc.AddProfile(new ServiceMappingProfile());
            //});

            //IMapper mapper = mappingConfig.CreateMapper();

            //services.AddSingleton(mapper);

            services.AddAutoMapper
           (
               typeof(ControllerMappingProfile).Assembly,
               typeof(ServiceProfile).Assembly

           );

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "CORE",
                    Version = "v1"
                });

                var basePath = AppContext.BaseDirectory;
                var xmlFiles = Directory.EnumerateFiles(basePath, "*.xml", SearchOption.TopDirectoryOnly);

                foreach (var xmlFile in xmlFiles)
                {
                    options.IncludeXmlComments(xmlFile);
                }
            });

            // database connection - Wldo
            this.WLDOonnection = this.Configuration.GetConnectionString("WLDO");

            // database connection - Mysql
            this.MySQLConnection = this.Configuration.GetConnectionString("MySQL");

            services.AddDbContext<MyDbContext>(options =>
            {
                options.UseSqlServer(this.Configuration.GetConnectionString("WLDO"));
            });

            //DB
            services.AddScoped<IDatabaseHelper>(x => new DatabaseHelper(WLDOonnection, MySQLConnection));

            //Dendency Injection

            services.AddDendencyInjection();

            services.AddControllers(options =>
            {
                options.Filters.Add<ActionResultFilter>();
                options.Filters.Add<ExceptionFilter>();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "CORE");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}