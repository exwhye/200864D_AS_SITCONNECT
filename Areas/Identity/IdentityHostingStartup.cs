using System;
using _200864D_AS_SITCONNECT.Areas.Identity.Data;
using _200864D_AS_SITCONNECT.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(_200864D_AS_SITCONNECT.Areas.Identity.IdentityHostingStartup))]
namespace _200864D_AS_SITCONNECT.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.Configure<IdentityOptions>(options =>
                {
                    // Default Lockout settings.
                    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(1);
                    options.Lockout.MaxFailedAccessAttempts = 3;
                    options.Lockout.AllowedForNewUsers = true;

                });


                services.AddDbContext<SITCONNECTDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("SITCONNECTDbContextConnection")));

                services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
                    .AddEntityFrameworkStores<SITCONNECTDbContext>();

                services.ConfigureApplicationCookie(options =>
                {
                    //set session expiry amd redirect
                    options.Cookie.Name = ".AspNetCore.Identity.Application";
                    options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
                    options.LoginPath = "/Account/Login";
                });
            });
        }
    }
}