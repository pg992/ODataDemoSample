﻿using System.Linq;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OData.Edm;
using ODataWebApiAspNetCore.Models;

namespace ODataWebApiAspNetCore
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
            services.AddDbContext<ODataDbContext>(options => options.UseSqlServer(Configuration["ODataDb"]));
            services.AddOData();
            services.AddMvc(options =>
            {
                options.EnableEndpointRouting = false;
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
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

            app.UseHttpsRedirection();
            app.UseMvc(routeBuilder =>
            {
                routeBuilder.EnableDependencyInjection();
                routeBuilder.Select().OrderBy().Filter().Expand().MaxTop(100).Count();//.SkipToken();
                routeBuilder.MapODataServiceRoute("odata", "odata", GetEdmModel());
            });
        }

        private static IEdmModel GetEdmModel()
        {
            var builder = new ODataConventionModelBuilder();
            builder.EntitySet<Company>("Companies");
            builder.EntitySet<Employee>("Employees");
            builder.EntitySet<Practice>("Practices");
            builder.EntitySet<Project>("Projects");

            var cu = builder.StructuralTypes.First(t => t.ClrType == typeof(Employee));
            cu.AddProperty(typeof(Employee).GetProperty("FullName"));
            var employee = builder.EntityType<Employee>();

            //employee.Ignore(t => t.FullName);
            //employeesBuilder.EntityType.Property(p => p.FirstName).Name = "Name";
            return builder.GetEdmModel();
        }
    }
}
