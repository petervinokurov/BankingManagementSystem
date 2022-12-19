using System;
using BankingManagmentSystem.Middlewares;
using Microsoft.AspNetCore.Builder;

namespace BankingManagmentSystem
{
	public static class ApplicationBuilderExtension
	{
        public static IApplicationBuilder UseBmpErrorHandler(this IApplicationBuilder applicationBuilder)
        => applicationBuilder.UseMiddleware<ApplicationErrorHandlingMiddleware>();
    }
}

