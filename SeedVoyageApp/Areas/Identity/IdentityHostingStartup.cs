using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SeedVoyageApp.Data;

[assembly: HostingStartup(typeof(SeedVoyageApp.Areas.Identity.IdentityHostingStartup))]
namespace SeedVoyageApp.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                //services.AddIdentity<ApplicationUser>();
            });
        }
    }
}