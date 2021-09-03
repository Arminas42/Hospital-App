using System;
using HospitalApp.Areas.Identity.Data;
using HospitalApp.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(HospitalApp.Areas.Identity.IdentityHostingStartup))]
namespace HospitalApp.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<DBContext>(options =>
                    options.UseMySql(
                        context.Configuration.GetConnectionString("DBContextConnection"), new MySqlServerVersion(new System.Version(8, 0, 11))));

                services.AddDefaultIdentity<User>(options =>
                {
                    options.SignIn.RequireConfirmedAccount = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                })
                    .AddRoles<IdentityRole>()
                    .AddEntityFrameworkStores<DBContext>();
            });
        }
    }
}