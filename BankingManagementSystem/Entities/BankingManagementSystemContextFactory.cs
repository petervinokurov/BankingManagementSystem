using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace BankingManagementSystem.Entities;

public class BankingManagementSystemContextFactory : IDesignTimeDbContextFactory<BankingManagementSystemContext>
{
    public BankingManagementSystemContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var connectionString = configuration.GetConnectionString("DefaultConnection");

        var optionsBuilder = new DbContextOptionsBuilder<BankingManagementSystemContext>();
        optionsBuilder.UseNpgsql(connectionString);
        return new BankingManagementSystemContext(optionsBuilder.Options);
    }
}
