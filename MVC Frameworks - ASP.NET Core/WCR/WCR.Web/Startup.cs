﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WCR.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WCR.Models;

namespace WCR.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddJsonFile(@"F:\base\customSettings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();

            if (env.IsDevelopment())
            {
                // This will push telemetry data through Application Insights pipeline faster, allowing you to view results immediately.
                //builder.AddApplicationInsightsSettings(developerMode: true);
            }
            Configuration = builder.Build();

            //Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<WCRDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("WCRConnection")));

            //services.AddDefaultIdentity<User>()
            //    .AddRoles<IdentityRole>()
            //    .AddEntityFrameworkStores<WCRDbContext>();

            services.AddIdentity<User, IdentityRole>()
                .AddDefaultUI()
                .AddDefaultTokenProviders()
                .AddEntityFrameworkStores<WCRDbContext>();
            
            services.Configure<IdentityOptions>(options =>
            {
                options.Password = new PasswordOptions()
                {
                    RequiredLength = 3,
                    RequireNonAlphanumeric = false,
                    RequireLowercase = false,
                    RequireUppercase = false
                };
            });

            services.AddAuthentication()
                .AddFacebook(options =>
                {
                    options.AppId = this.Configuration.GetSection("ExternalAuthentication:Facebook:AppId").Value;
                    options.AppSecret = this.Configuration.GetSection("ExternalAuthentication:Facebook:AppSecret").Value;
                });

            //services.Configure<CustomSection1>(options => Configuration.GetSection("CustomSection1").Bind(options));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            //var roles = new string[] { "Administrator", "Moderator"};
            var roles = this.Configuration.GetSection("Roles").AsEnumerable().Select(x => x.Value).Skip(1).ToArray();
            //CreateRoles(serviceProvider, roles);
        }

        private void CreateRoles(IServiceProvider serviceProvider, string[] roles)
        {

            var userManager = serviceProvider.GetRequiredService<UserManager<User>>();
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            string userName = "niki";

            //Check that there is an Administrator role and create if not
            foreach (var role in roles)
            {
                CreateRole(roleManager, role);
            }            

            //Check if the admin user exists and create it if not
            //Add to the Administrator role

            Task<User> testUser = userManager.FindByNameAsync(userName);
            testUser.Wait();

            if (testUser.Result == null)
            {
                User administrator = new User();
                //administrator.Email = email;
                administrator.UserName = userName;

                Task<IdentityResult> newUser = userManager.CreateAsync(administrator, "123");
                newUser.Wait();

                if (newUser.Result.Succeeded)
                {
                    Task<IdentityResult> newUserRole = userManager.AddToRoleAsync(administrator, "Administrator");
                    newUserRole.Wait();
                }
            }
            else
            {
                Task<IdentityResult> newUserRole = userManager.AddToRoleAsync(testUser.Result, "Administrator");
                newUserRole.Wait();

                var userRoles = userManager.GetRolesAsync(testUser.Result);
                userRoles.Wait();
            }
        }

        private static void CreateRole(RoleManager<IdentityRole> roleManager, string roleName)
        {
            var hasAdminRole = roleManager.RoleExistsAsync(roleName);
            hasAdminRole.Wait();

            if (!hasAdminRole.Result)
            {
                var roleResult = roleManager.CreateAsync(new IdentityRole(roleName));
                roleResult.Wait();
            }
        }
    }
}
