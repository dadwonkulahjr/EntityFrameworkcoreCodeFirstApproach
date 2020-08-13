using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityFrameworkcoreCodeFirstApproach.Models;
using EntityFrameworkcoreCodeFirstApproach.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Builder.Internal;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EntityFrameworkcoreCodeFirstApproach
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public Startup(IConfiguration config)
        {
            this._configuration = config;
            
        }
        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddMvc(options => {
                var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser()
                                .Build();
                options.Filters.Add(new AuthorizeFilter(policy));
            });
            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
             
                options.Password.RequiredLength = 10;
                options.Password.RequiredUniqueChars = 3;
                options.User.AllowedUserNameCharacters = options.User.AllowedUserNameCharacters;

            }).AddEntityFrameworkStores<SQLDbContext>();

            services.ConfigureApplicationCookie(options =>
            {
                options.AccessDeniedPath = new PathString("/Administration/AccessDenied");
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("DeleteRolePolicy", policy => policy.RequireClaim("Delete Role"));

                options.AddPolicy("EditRolePolicy", policy =>
                {
                    policy.AddRequirements(new ManageAdminRolesAndCliamsRequirements());
                });
                            
                options.AddPolicy("AdminRolePolicy", policy => policy.RequireRole("Admin"));
              

            });
            services.AddScoped<IEmployeeRepositoryPattern, SQLImplementation>();
            services.AddSingleton<IAuthorizationHandler, CanEditOnlyAdminRolesAndClaimsHandler>();
            services.AddSingleton<IAuthorizationHandler, SuperAdminHandler>();
            services.AddDbContextPool<SQLDbContext>(options =>
            {
                options.UseSqlServer(_configuration.GetConnectionString("DbConnections"));
            });

            services.AddAuthentication().AddGoogle(options =>
            {
                options.ClientId = "810438046397-61f7tcisqmg2noah92abpubman7ov58f.apps.googleusercontent.com";
                options.ClientSecret = "A6VNHH1OwJWygQYq90l46Iw3";
            });

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
                app.UseExceptionHandler("/Error");
                app.UseStatusCodePagesWithReExecute("/Error/{0}");
            }
            //app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseMvc(configureRoutes: routes =>
             {
                 routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
             });


        }
    }
}
