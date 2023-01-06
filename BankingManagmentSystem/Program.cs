using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using NLog;
using NLog.Web;

namespace BankingManagmentSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
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
