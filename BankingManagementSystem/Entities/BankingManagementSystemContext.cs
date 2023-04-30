using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace BankingManagementSystem.Entities
{
    public class BankingManagementSystemContext : IdentityDbContext<User, Role, Guid, IdentityUserClaim<Guid>, IdentityUserRole<Guid>, IdentityUserLogin<Guid>, RoleClaim, IdentityUserToken<Guid>>
    {
        public DbSet<Account> Accounts { get; set; }

        public DbSet<Currency> Currencies { get; set; }

        public DbSet<CurrencyRate> CurrencyRates { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Transaction> Transactions { get; set; }

        private readonly DatabaseSettings _databaseSettings;

        private readonly DemoDataProvider _demoDataProvider = new DemoDataProvider();

        public BankingManagementSystemContext(IOptions<DatabaseSettings> databaseSettings, DbContextOptions<BankingManagementSystemContext> options)
            : base(options)
        {
            _databaseSettings = databaseSettings?.Value;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseNpgsql(_databaseSettings.ConnectionString);

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasKey(b => b.Id);
            modelBuilder.Entity<User>()
                .Property(b => b.Id).HasDefaultValueSql("gen_random_uuid()");
            modelBuilder.Entity<User>().HasMany<IdentityUserToken<Guid>>().WithOne().HasForeignKey(uc => uc.UserId).IsRequired();
            modelBuilder.Entity<User>().HasMany<IdentityUserToken<Guid>>().WithOne().HasForeignKey(ul => ul.UserId).IsRequired();
            modelBuilder.Entity<User>().HasMany<IdentityUserToken<Guid>>().WithOne().HasForeignKey(ut => ut.UserId).IsRequired();
            modelBuilder.Entity<User>().HasMany<IdentityUserRole<Guid>>().WithOne().HasForeignKey(ur => ur.UserId).IsRequired();
            modelBuilder.Entity<User>()
                .Property(b => b.Email).HasMaxLength(256);
            modelBuilder.Entity<User>()
                .Property(b => b.UserName).HasMaxLength(256);
            modelBuilder.Entity<User>()
                .Property(b => b.NormalizedEmail).HasMaxLength(256);
            modelBuilder.Entity<User>()
                .Property(b => b.NormalizedUserName).HasMaxLength(256);
            modelBuilder.Entity<User>()
                .HasIndex(b => b.NormalizedEmail).HasDatabaseName("EmailNameIndex").IsUnique();
            modelBuilder.Entity<User>()
                .HasIndex(b => b.UserName).HasDatabaseName("UserNameIndex");

            modelBuilder.Entity<User>().HasData(_demoDataProvider.GetSystemAdmin());

            modelBuilder.Entity<Role>()
                .HasKey(b => b.Id);
            modelBuilder.Entity<Role>()
                .Property(b => b.Id).HasDefaultValueSql("gen_random_uuid()");
            modelBuilder.Entity<Role>()
                .HasIndex(b => b.NormalizedName).HasDatabaseName("RoleNameIndex").IsUnique();
            modelBuilder.Entity<Role>()
                .Property(b => b.NormalizedName).HasMaxLength(256);
            modelBuilder.Entity<Role>()
                .Property(b => b.Name).HasMaxLength(256);
            modelBuilder.Entity<Role>()
                .Property(b => b.ConcurrencyStamp).IsConcurrencyToken();
            modelBuilder.Entity<Role>().HasData(_demoDataProvider.GetDefaultSystemRoles());
            
            modelBuilder.Entity<User>()
                .HasMany(p => p.Roles)
                .WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "UserRole",
                    j => j
                        .HasOne<Role>()
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .HasConstraintName("FK_UserRole_Roles_UserId")
                        .OnDelete(DeleteBehavior.Cascade),
                    j => j
                        .HasOne<User>()
                        .WithMany()
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_UserRole_Users_RoleId")
                        .OnDelete(DeleteBehavior.ClientCascade));
            
            modelBuilder.Entity<IdentityUserRole<Guid>>()
                .HasKey(r => new { r.UserId, r.RoleId });

            modelBuilder.Entity<IdentityUserLogin<Guid>>()
                .HasKey(b => new { b.LoginProvider, b.ProviderKey });
            modelBuilder.Entity<IdentityUserLogin<Guid>>()
                .Property(b => b.LoginProvider).HasMaxLength(256);
            modelBuilder.Entity<IdentityUserLogin<Guid>>()
                .Property(b => b.ProviderKey).HasMaxLength(256);
            
            modelBuilder.Entity<IdentityUserToken<Guid>>()
                .HasKey(t => new { t.UserId, t.LoginProvider, t.Name });

            modelBuilder.Entity<IdentityUserClaim<Guid>>()
                .HasKey(b => b.Id);
            modelBuilder.Entity<IdentityUserClaim<Guid>>()
                .Property(b => b.Id).UseIdentityColumn();
            modelBuilder.Entity<IdentityUserClaim<Guid>>()
                .HasKey(b => b.Id);

            modelBuilder.Entity<Account>()
                .HasKey(b => b.Id);
            modelBuilder.Entity<Account>()
                .Property(b => b.Id).UseIdentityColumn();
            //modelBuilder.Entity<Account>()
            //    .Property(b => b.CreatedAt).HasDefaultValueSql("now() at time zone 'utc'");
            modelBuilder.Entity<Account>()
                .Property(b => b.CreatedAt).IsRequired();
            modelBuilder.Entity<Account>()
                .Property(b => b.Number).HasMaxLength(18);
            modelBuilder.Entity<Account>()
                .Property(b => b.Balance).IsRequired();
            modelBuilder.Entity<Account>()
                .Property(b => b.Balance).HasDefaultValue(0);
            modelBuilder.Entity<Account>()
                .Property(b => b.CurrencyCode).IsRequired();
            modelBuilder.Entity<Account>()
                .Property(b => b.CurrencyCode).HasDefaultValue("USD");
            modelBuilder.Entity<Account>()
                .Property(x => x.CustomerId).IsRequired();
            modelBuilder.Entity<Account>()
                .HasOne(b => b.Currency)
                .WithMany(b => b.Accounts)
                .HasForeignKey(b => b.CurrencyCode);
            modelBuilder.Entity<Account>()
                .HasMany(b => b.Transactions)
                .WithOne(b => b.Account)
                .HasForeignKey(b => b.AccountId);

            modelBuilder.Entity<Currency>()
                .HasKey(b => b.Code);
            modelBuilder.Entity<Currency>()
                .Property(b => b.Code).HasMaxLength(3);
            modelBuilder.Entity<Currency>()
                .Property(b => b.Description).IsRequired();
            modelBuilder.Entity<Currency>()
                .Property(b => b.Description).HasMaxLength(50);
            modelBuilder.Entity<Currency>()
                .HasMany(x => x.CurrencyRates)
                .WithOne(b => b.Currency)
                .HasForeignKey(b => b.CurrencyCode);
            modelBuilder.Entity<Currency>()
                .HasMany(b => b.Accounts)
                .WithOne(b => b.Currency)
                .HasForeignKey(b => b.CurrencyCode);
            modelBuilder.Entity<Currency>()
                .HasMany(b => b.Transactions)
                .WithOne(b => b.Currency)
                .HasForeignKey(b => b.CurrencyCode);

            modelBuilder.Entity<CurrencyRate>()
                .HasKey(b => b.Id);
            modelBuilder.Entity<CurrencyRate>()
                .Property(b => b.Id).UseIdentityColumn();
            modelBuilder.Entity<CurrencyRate>()
                .Property(b => b.CreatedAt).IsRequired();
            //modelBuilder.Entity<CurrencyRate>()
             //   .Property(b => b.CreatedAt).HasDefaultValueSql("now() at time zone 'utc'");
            modelBuilder.Entity<CurrencyRate>()
                .Property(b => b.Value).IsRequired();
            modelBuilder.Entity<CurrencyRate>()
                .Property(b => b.Value).HasDefaultValue(0);
            modelBuilder.Entity<CurrencyRate>()
                .Property(b => b.CurrencyCode).IsRequired();
            modelBuilder.Entity<CurrencyRate>()
                .HasOne(b => b.Currency);
            modelBuilder.Entity<CurrencyRate>()
                .HasOne(b => b.Currency)
                .WithMany(b => b.CurrencyRates)
                .HasForeignKey(b => b.CurrencyCode);

            modelBuilder.Entity<Transaction>()
                .HasKey(b => b.Id);
            modelBuilder.Entity<Transaction>()
                .Property(b => b.Id).UseIdentityColumn();
            modelBuilder.Entity<Transaction>()
                .Property(b => b.CreatedAt).IsRequired();
            //modelBuilder.Entity<Transaction>()
            //    .Property(b => b.CreatedAt).HasDefaultValueSql("now() at time zone 'utc'");
            modelBuilder.Entity<Transaction>()
                .Property(b => b.Amount).HasDefaultValue(0);
            modelBuilder.Entity<Transaction>()
                .Property(b => b.Amount).IsRequired();
            modelBuilder.Entity<Transaction>()
                .HasOne(b => b.Currency)
                .WithMany(b => b.Transactions)
                .HasForeignKey(b => b.CurrencyCode);
            modelBuilder.Entity<Transaction>()
                .HasOne(b => b.CurrencyOnDate)
                .WithMany(b => b.Transactions)
                .HasForeignKey(b => b.CurrencyRateId);
            modelBuilder.Entity<Transaction>()
                .HasOne(b => b.Account)
                .WithMany(b => b.Transactions)
                .HasForeignKey(b => b.AccountId);
            modelBuilder.Entity<Transaction>()
                .Property(b => b.Type).IsRequired();

            modelBuilder.Entity<Customer>()
                .HasKey(b => b.Id);
            modelBuilder.Entity<Customer>()
                .Property(b => b.Id).UseIdentityColumn();
            modelBuilder.Entity<Customer>()
                .Property(b => b.CreatedAt).IsRequired();
            modelBuilder.Entity<Customer>()
                .Property(b => b.CreatedAt).HasDefaultValueSql("now() at time zone 'utc'");
            modelBuilder.Entity<Customer>()
                .Property(b => b.Name).IsRequired();
            modelBuilder.Entity<Customer>()
                .HasMany(b => b.Accounts)
                .WithOne(b => b.Customer);

            modelBuilder.Entity<Log>()
                .HasKey(b => b.Id);
            modelBuilder.Entity<Log>()
                .Property(b => b.Id).UseIdentityColumn();
            modelBuilder.Entity<Log>()
                .Property(b => b.MachineName).HasMaxLength(50);
            modelBuilder.Entity<Log>()
                .Property(b => b.MachineName).IsRequired();
            modelBuilder.Entity<Log>()
                .Property(b => b.Logged).IsRequired();
            modelBuilder.Entity<Log>()
                .Property(b => b.Message).IsRequired();
            modelBuilder.Entity<Log>()
                .Property(b => b.Level).HasMaxLength(50);
            modelBuilder.Entity<Log>()
                .Property(b => b.Level).IsRequired();
            modelBuilder.Entity<Log>()
                .Property(b => b.Logger).HasMaxLength(250);
            modelBuilder.Entity<Log>()
                .Property(b => b.UserPermissions).HasMaxLength(250);


        }
    }
}
