﻿using System.Linq;
using BankingManagementSystem.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NLog;
using NLog.Web;

namespace BankingManagementSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<BankingManagementSystemContext>();
                var demoDataProvider = new DemoDataProvider();
                if (db.Users.Count() < DemoDataProvider.UserCount)
                {
                    db.Users.AddRange(demoDataProvider.Fake1000Users());
                    db.SaveChanges();
                }
            }
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    var logger = LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
                    webBuilder.UseNLog().UseStartup<Startup>();
                });
    }
}
