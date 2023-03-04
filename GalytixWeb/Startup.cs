using GalytixWeb.DataAccess;
using GalytixWeb.DataAccess.Abstractions;
using GalytixWeb.DataAccess.Repositories;
using GalytixWeb.Services;
using GalytixWeb.Services.Abstractions;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GalytixWeb
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
            services.AddScoped<IGWPRepository, GWPRepository>();
            services.AddDbContext<InMemoryContext>(opt => opt.UseInMemoryDatabase("testDb"));
            services.AddScoped<IGWPService, GWPService>();
            services.AddSingleton(x =>
            {
                var basePath = AppContext.BaseDirectory;
                return new DbSeeder(basePath);
            });
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, InMemoryContext inMemoryContext)
        {
            inMemoryContext.Database.EnsureCreated();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UsePathBase("/server");
            app.UseRouting();


            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
