using System;
using System.Text;
using AutoMapper;
using BankingManagementSystem.Entities;
using BankingManagementSystem.Middlewares;
using BankingManagementSystem.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace BankingManagementSystem;

public class Startup
{
    private readonly AppSettings _appSettings;

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
        _appSettings = configuration.Get<AppSettings>();
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddMediatR(cfg => {
            cfg.RegisterServicesFromAssembly(typeof(Program).Assembly);
        });
            
        services.AddLogging();
        services.AddMvc();

        services.AddAntiforgery(options =>
        {
            options.HeaderName = "X-XSRF-TOKEN";
            options.Cookie = new CookieBuilder
            {
                Name = "XSRF-TOKEN", SameSite = SameSiteMode.Strict, HttpOnly = true, IsEssential = true
            };
        });
        
        services.AddCors(options =>
            options.AddPolicy("AllowNgApp", p => p
                .WithOrigins("https://localhost:5001")
                .AllowCredentials()
                .AllowAnyMethod()
                .AllowAnyHeader()));
        services.Configure<DatabaseSettings>(Configuration.GetSection("Database"));
        services.Configure<JwtSettings>(Configuration.GetSection("Jwt"));

        services.AddDbContext<BankingManagementSystemContext>();
        services.AddHttpContextAccessor();
        services.AddIdentityCore<User>(options => options.SignIn.RequireConfirmedAccount = true)
            .AddRoles<Role>()
            .AddEntityFrameworkStores<BankingManagementSystemContext>();
        services.AddTransient<IClaimPairsService, ClaimPairsService>();
        services.AddTransient<ICustomerService, CustomerService>();
        services.AddTransient<ITokenService, TokenService>();
        services.AddTransient<IIdentityService, IdentityService>();
        services.AddSingleton<ICryptographyService, CryptographyService>();
        services.AddDistributedMemoryCache();
            
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = _appSettings.Jwt.Issuer,
                ValidAudience = _appSettings.Jwt.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.Jwt.Key))
            };
        });
        services.AddControllers(options =>
        {
            options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
        });
        services.AddSpaStaticFiles(options =>
        {
            options.RootPath = "ClientApp/dist";
        });

        services.AddSingleton(new MapperConfiguration(mc =>
        {
            mc.AddProfile(new MappingProfile(new CryptographyService()));
        }).CreateMapper());
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseMiddleware<ApplicationErrorHandlingMiddleware>();
        app.UseSpaStaticFiles();
            
        app.UseHttpsRedirection();
        app.UseRouting();
            
        app.UseCors();

        app.UseMiddleware<RefreshTokenMiddleware>();
        
        app.UseAuthentication();
        app.UseAuthorization();
            
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
            endpoints.Map("api/{**slug}", ctx => throw new Exception($"Wrong route {ctx.Request.Path}"));
                
        }).UseSpa(spa => {
            spa.Options.SourcePath = "ClientApp";
        }); 
    }
}