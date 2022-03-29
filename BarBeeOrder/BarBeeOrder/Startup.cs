using AspNetCoreHero.ToastNotification;
using BarBeeOrder.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using System.Threading.Tasks;

namespace BarBeeOrder
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
            string stringConnnectDb = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<BarBeeOrderContext>(option => option.UseSqlServer(stringConnnectDb));
            services.AddNotyf(config => { config.DurationInSeconds = 5;config.IsDismissable = true; config.Position = NotyfPosition.TopRight; });
            services.AddSession();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(
                p=>
                {
                    p.LoginPath = "/dang-nhap.html";
                    p.AccessDeniedPath = "/";
                });
            services.AddSingleton<HtmlEncoder>(HtmlEncoder.Create(allowedRanges: new[] {UnicodeRanges.All}));
            services.AddControllersWithViews().AddRazorRuntimeCompilation();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                //app.UseDeveloperExceptionPage();
                app.UseExceptionHandler("/Error/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            else
            {
                app.UseExceptionHandler("/Error/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.Use(async (context, next) =>
            {
                await next();
                if (context.Response.StatusCode == 404 || context.Response.StatusCode == 500)
                {
                    context.Request.Path = "/Error/Error";
                    await next();
                }
                
                
            });
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                
                endpoints.MapControllerRoute(
                  name: "areas",
                  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");


            });
        }
    }
}
