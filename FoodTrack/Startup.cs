using System;
using System.IO;
using System.Reflection;
using FoodTrack.DataAccess;
using FoodTrack.DataAccess.Data;
using FoodTrack.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace FoodTrack
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
            DbGlobalSettings.ConnectionString = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<FoodTrackDbContext>(options =>
                                         options.UseLazyLoadingProxies().UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.CustomOperationIds(e => $"{e.ActionDescriptor.RouteValues["controller"]}_{e.ActionDescriptor.RouteValues["action"]}");
                c.SwaggerDoc("v1", new Info
                {
                    Title = "FoodTrack - API",
                    Version = "v1"
                });


                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var baseDirectory = AppContext.BaseDirectory;
                var xmlPath = Path.Combine(baseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
                // Enable Annotations
                c.EnableAnnotations();
            });

            services.AddRouting(options =>
            {
                options.LowercaseUrls = true;
                options.LowercaseQueryStrings = true;
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);


            services.AddTransient<IExcelService, ExcelService>();
            services.AddTransient<IEmailService, EmailService>();

            //application services
            //entity services
            services.AddScoped<ICategoryItemService, CategoryItemService>();
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseStaticFiles();
            app.UseHttpsRedirection();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger(o =>
            {
                o.RouteTemplate = "docs/{documentName}/docs.json";
            });

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(o =>
            {
                o.DocumentTitle = "Swagger UI - FoodTrack";
                o.SwaggerEndpoint("/docs/v1/docs.json", "FoodTrack - API");
                o.RoutePrefix = "docs";
                o.DisplayOperationId();
            });
            app.UseMvc();
        }
    }
}
