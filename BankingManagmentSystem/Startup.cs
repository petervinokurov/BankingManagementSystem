using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using BankingManagmentSystem.Entities;
using AutoMapper;
using BankingManagmentSystem.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Http;
using static System.Net.Mime.MediaTypeNames;

namespace BankingManagmentSystem
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSpaStaticFiles(options =>
            {
                options.RootPath = "ClientApp";
            });

            services.AddCors(options =>
              options.AddPolicy("AllowNgApp", p => p
                  .WithOrigins("https://localhost:5001")
                  .AllowCredentials()
                  .AllowAnyMethod()
                  .AllowAnyHeader()));

            services.AddDbContext<BankingManagmentSystemContext>();
            services.AddHttpContextAccessor();
            services.AddIdentityCore<BmcUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<BankingManagmentSystemContext>();
            services.AddTransient<ICustomerService, CustomerService>();
            services.AddTransient<ITokenService, TokenService>();
            services.AddTransient<IIdentityService, IdentityService>();
            services.AddDistributedMemoryCache();
            services.AddSession();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = Configuration["Jwt:Issuer"],
                    ValidAudience = Configuration["Jwt:Issuer"],
                    IssuerSigningKey = new
                    SymmetricSecurityKey
                    (Encoding.UTF8.GetBytes
                    (Configuration["Jwt:Key"]))
                };
            });
            services.AddControllers();

            services.AddSingleton(new MapperConfiguration(mc => { mc.AddProfile(new MappingProfile()); }).CreateMapper());

            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseRouting();

            app.UseCors();

            


            app.UseSession();
            app.Use(async (context, next) =>
            {
                var token = context.Session.GetString("Token");
                if (!string.IsNullOrEmpty(token))
                {
                    context.Request.Headers.Add("Authorization", "Bearer " + token);
                }
                await next();
            });
            app.UseAuthentication();
            app.UseAuthorization();
            

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseSpaStaticFiles();
            app.UseSpa(spa => {
            });
        }
    }
}
