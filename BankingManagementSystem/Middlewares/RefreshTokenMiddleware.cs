using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using BankingManagementSystem.Entities;
using BankingManagementSystem.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BankingManagementSystem.Middlewares;

public class RefreshTokenMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ITokenService _tokenService;
    private readonly IServiceProvider _serviceProvider;
    private readonly IMapper _mapper;
    private const string Token = "Token";

    public RefreshTokenMiddleware(RequestDelegate next, 
        ITokenService tokenService, 
        IMapper mapper,
        IServiceProvider serviceProvider)
    {
        _next = next;
        _tokenService = tokenService;
        _serviceProvider = serviceProvider;
        _mapper = mapper;
    }
    
    public async Task Invoke(HttpContext context)
    {
        var token = context.Request.Cookies[Token];
        if (!_tokenService.ValidateToken(token) && token != null)
        {
            var securityToken = _tokenService.ReadToken(token) as JwtSecurityToken;
            var emailClaim = securityToken?.Claims.First(x => x.Type == ClaimTypes.Email);

            using var scope = _serviceProvider.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<BankingManagementSystemContext>();
            var validUser = await dbContext.Users
                .Where(x => x.NormalizedEmail == emailClaim.Value.ToUpper())
                .ProjectTo<UserDto>(_mapper.ConfigurationProvider).SingleOrDefaultAsync();

            var savedToken = await dbContext.UserTokens.SingleOrDefaultAsync(x => x.UserId == validUser.Id);
            if (_tokenService.ValidateToken(savedToken?.Value))
            {
                token = _tokenService.BuildAccessToken(validUser);
                context.Response.Cookies.Delete(Token);
                context.Response.Cookies.Append(Token, token);
            }
        }
        context.Request.Headers.Add("Authorization", "Bearer " + token);
        await _next(context);
    }
}