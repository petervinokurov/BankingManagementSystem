using BankingManagementSystem.Middlewares;
using Microsoft.AspNetCore.Builder;

namespace BankingManagementSystem
{
	public static class ApplicationBuilderExtension
	{
        public static IApplicationBuilder UseBmpErrorHandler(this IApplicationBuilder applicationBuilder)
        => applicationBuilder.UseMiddleware<ApplicationErrorHandlingMiddleware>();
    }
}

