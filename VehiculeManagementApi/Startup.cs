using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InterfaceService.Implementations;
using InterfaceService.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Repositories.Interfaces;
using Repositories.MockRepositories;
using Repositories.Repository;

namespace VehiculeManagementApi
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
            services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            //services.AddDefaultIdentity<IdentityUser>().AddEntityFrameworkStores<ApplicationContext>();
            services.AddScoped<IVehiculeRepository, VehiculeRepository>();
            services.AddScoped<IModelRepository, VehiculeModelRepository>();

            //pour tester sans la base de donnée
            //services.AddScoped<IVehiculeRepository, MockVehiculeRepository>();
            //services.AddScoped<IModelRepository, MockVehiculeModelRepository>();

            services.AddTransient<IVehiculeService, VehiculeService>(); 
            services.AddTransient<IModelService, ModelService>();
            services.AddControllers();
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
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
