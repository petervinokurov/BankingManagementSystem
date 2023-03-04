using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace BankingManagementSystem.Entities
{
    public class BankingManagementSystemContext : IdentityDbContext<BmsUser, BmsRole, Guid>
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
            modelBuilder.Entity<BmsUser>()
                .HasKey(b => b.Id);
            modelBuilder.Entity<BmsUser>()
                .Property(b => b.Id).HasDefaultValueSql("gen_random_uuid()");
            modelBuilder.Entity<BmsUser>().HasMany<IdentityUserClaim<Guid>>().WithOne().HasForeignKey(uc => uc.UserId).IsRequired();
            modelBuilder.Entity<BmsUser>().HasMany<IdentityUserLogin<Guid>>().WithOne().HasForeignKey(ul => ul.UserId).IsRequired();
            modelBuilder.Entity<BmsUser>().HasMany<IdentityUserToken<Guid>>().WithOne().HasForeignKey(ut => ut.UserId).IsRequired();
            modelBuilder.Entity<BmsUser>().HasMany<IdentityUserRole<Guid>>().WithOne().HasForeignKey(ur => ur.UserId).IsRequired();
            modelBuilder.Entity<BmsUser>()
                .Property(b => b.Email).HasMaxLength(256);
            modelBuilder.Entity<BmsUser>()
                .Property(b => b.UserName).HasMaxLength(256);
            modelBuilder.Entity<BmsUser>()
                .Property(b => b.NormalizedEmail).HasMaxLength(256);
            modelBuilder.Entity<BmsUser>()
                .Property(b => b.NormalizedUserName).HasMaxLength(256);
            modelBuilder.Entity<BmsUser>()
                .HasIndex(b => b.NormalizedEmail).HasDatabaseName("EmailNameIndex").IsUnique();
            modelBuilder.Entity<BmsUser>()
                .HasIndex(b => b.UserName).HasDatabaseName("UserNameIndex");

            modelBuilder.Entity<BmsUser>().HasData(_demoDataProvider.GetSystemAdmin());

            modelBuilder.Entity<BmsRole>()
                .HasKey(b => b.Id);
            modelBuilder.Entity<BmsRole>()
                .Property(b => b.Id).HasDefaultValueSql("gen_random_uuid()");
            modelBuilder.Entity<BmsRole>()
                .HasIndex(b => b.NormalizedName).HasDatabaseName("RoleNameIndex").IsUnique();
            modelBuilder.Entity<BmsRole>()
                .HasMany<IdentityRoleClaim<Guid>>().WithOne().HasForeignKey(rc => rc.RoleId).IsRequired();
            modelBuilder.Entity<BmsRole>()
                .Property(b => b.NormalizedName).HasMaxLength(256);
            modelBuilder.Entity<BmsRole>()
                .Property(b => b.Name).HasMaxLength(256);
            modelBuilder.Entity<BmsRole>()
                .Property(b => b.ConcurrencyStamp).IsConcurrencyToken();

            modelBuilder.Entity<BmsRole>().HasData(_demoDataProvider.GetDefaultSystemRoles());

            modelBuilder.Entity<IdentityUserLogin<Guid>>()
                .HasKey(b => new { b.LoginProvider, b.ProviderKey });
            modelBuilder.Entity<IdentityUserLogin<Guid>>()
                .Property(b => b.LoginProvider).HasMaxLength(256);
            modelBuilder.Entity<IdentityUserLogin<Guid>>()
                .Property(b => b.ProviderKey).HasMaxLength(256);

            modelBuilder.Entity<IdentityUserRole<Guid>>()
                .HasKey(r => new { r.UserId, r.RoleId });


            modelBuilder.Entity<IdentityUserToken<Guid>>()
                .HasKey(t => new { t.UserId, t.LoginProvider, t.Name });

            modelBuilder.Entity<IdentityUserClaim<Guid>>()
                .HasKey(b => b.Id);
            modelBuilder.Entity<IdentityUserClaim<Guid>>()
                .Property(b => b.Id).UseIdentityColumn();

            modelBuilder.Entity<IdentityRoleClaim<Guid>>()
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
