using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace BankingManagementSystem.Middlewares;

public class ValidateAntiforgeryToken : IAsyncActionFilter
{
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var antiForgery = context.HttpContext.RequestServices.GetRequiredService(typeof(IAntiforgery)) as IAntiforgery;
        var csrfSettings = context.HttpContext.RequestServices.GetRequiredService(typeof(IOptions<CsrfSettings>)) as IOptions<CsrfSettings>;
        var executingEndpoint = context.HttpContext.GetEndpoint();

        var attributes = executingEndpoint?.Metadata.OfType<IgnoreAntiforgeryTokenAttribute>() ?? new List<IgnoreAntiforgeryTokenAttribute>();

        if (!attributes.Any())
        {
            var tokenSet = antiForgery?.GetTokens(context.HttpContext);
            if (csrfSettings?.Value.CsrfHeader != null)
                context.HttpContext.Request.Headers.Add(csrfSettings.Value.CsrfHeader, tokenSet?.RequestToken);
            await antiForgery?.ValidateRequestAsync(context.HttpContext)!;
        }
        
        await next();
    }
}