using System;
using Factory.Factories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Filters;
using System.Diagnostics.CodeAnalysis;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.IO;

namespace WebApi
{
    [ExcludeFromCodeCoverage]
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
            services.AddCors(options =>
            {
                options.AddPolicy("AllowEverything",builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            });
            
            services.AddControllers(options => options.Filters.Add(typeof(ExceptionFilter)));
            ServiceFactory factory = new ServiceFactory(services);
            services.AddControllers();
            factory.AddCustomServices();
            factory.AddDbContextService();
            services.AddSwaggerGen();

            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.XML";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "UrugayNaturalRequest", Version = "v1" });
                options.IncludeXmlComments(xmlPath);
                //options.OperationFilter<ExceptionFilter>();
            });
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

            app.UseCors();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = "";
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "UruguayNatural Request");
            });
            app.UseStaticFiles();
        }
    }
}
