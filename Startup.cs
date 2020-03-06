using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MvcMovie.Data;
using MvcMovie.Models;
using Microsoft.EntityFrameworkCore;

namespace MvcMovie
{
    public class Startup
    {
       
             public IConfiguration Configuration { get; }
             public IWebHostEnvironment Environment { get; }

            public Startup(IConfiguration configuration, IWebHostEnvironment env) 
            {
            Environment = env;
            Configuration = configuration;
                
            }
        
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
                    services.AddControllersWithViews();

                services.AddDbContext<MvcMovie.Data.MvcMovieContext>(options =>
                {
                    var connectionString = Configuration.GetConnectionString("MvcMovieContext");

                    if (Environment.IsDevelopment())
                    {
                        options.UseSqlite(connectionString);
                    }
                    else
                    {
                        var connectionString2 = Configuration.GetConnectionString("MvcMovieContext2");
                        options.UseSqlServer(connectionString2);
                    }
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
                else
                {
                    app.UseExceptionHandler("/Home/Error");
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
                        pattern: "{controller=Movies}/{action=Index}/{id?}");
                });
    
        }
    }
}
