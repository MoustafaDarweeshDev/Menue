using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.StaticFiles;
using System.Text;
using Microsoft.AspNetCore.HttpOverrides;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc.Razor;
using System.Reflection;
using System.Globalization;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Options;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using Microsoft.AspNetCore.Razor.TagHelpers;
using infrastructure.Data;
using core.Interfaces;

namespace POSTest
{
    public class Startup
    {
        string AllowCors = "CorsPolicy";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IItemsRepository,ItemsRepository>();
            services.AddScoped<IOrdersRepository, OrdersRepository>();
            services.AddScoped<IBasketRepository , BasketRepository>();
            services.AddDbContext<PostContext>(o=>o.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddSignalR();
            services.AddControllersWithViews().AddRazorRuntimeCompilation().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.MaxDepth = 0;
            }).AddRazorRuntimeCompilation();


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Latest);

            services.AddMvc(options => options.EnableEndpointRouting = false);
            services.AddDistributedMemoryCache();
            services.AddSession(so =>
            {
                so.IdleTimeout = TimeSpan.FromMinutes(20);
            });

            services.AddDataProtection();
            services.AddCors(options =>
            {
                options.AddPolicy(AllowCors, options =>
               {
                   options.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
               });
            });

            #region Services Injection
            services.AddHttpContextAccessor();
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // using Microsoft.AspNetCore.HttpOverrides;

            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

            }
            else
            {
                app.UseStatusCodePagesWithRedirects("/Error/{0}");
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCors(AllowCors);

            app.UseRouting();
            app.UseCors();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSession();

            app.UseMvc(routes =>
            {
                routes.MapRoute("default",
                    "{controller}/{action}/{id?}",
                    new { controller = "Home", action = "Index" }
                );
            });
        }
    }
}
