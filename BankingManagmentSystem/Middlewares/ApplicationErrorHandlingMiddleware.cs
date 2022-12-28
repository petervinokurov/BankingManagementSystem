using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using BankingManagmentSystem.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using NLog;

namespace BankingManagmentSystem.Middlewares
{
	public class ApplicationErrorHandlingMiddleware
	{
		private readonly RequestDelegate _next;
        private readonly ILogger<ApplicationErrorHandlingMiddleware> _logger;
        const int MaxBodyLength = 30000; //A body bigger than that will be swop into the file system.
        const string ContentType = "application/json";

        public ApplicationErrorHandlingMiddleware(RequestDelegate next,
            
            ILogger<ApplicationErrorHandlingMiddleware> logger
            )
		{
			_next = next;
            _logger = logger;
		}

        public async Task Invoke(HttpContext context)
        {
            try
            {
                if (context.Request.ContentType == ContentType && context.Request.ContentLength <= MaxBodyLength)
                {
                    context.Request.EnableBuffering();
                }
                
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            HttpStatusCode status;
            var request = context.Request;
            var requestParametersBuilder = new StringBuilder();

            switch (exception)
            {
                case
                    NotImplementedException:
                    status = HttpStatusCode.NotImplemented;
                    break;
                case
                    UnauthorizedAccessException:
                    status = HttpStatusCode.Unauthorized;
                    break;
                default:
                    status = HttpStatusCode.InternalServerError;
                    break;
            }
            if (request.Method == HttpMethods.Put)
            if (request.QueryString.HasValue)
            {
                requestParametersBuilder.Append($"Query: {request.QueryString.ToString()}");
            }

            if (context.Request.ContentType == ContentType && request.ContentLength > 0 && request.ContentLength <= MaxBodyLength)
            {
                request.Body.Position = 0;
                var reader = new StreamReader(request.Body);
                var body = await reader.ReadToEndAsync();
                if (requestParametersBuilder.Length > 0) requestParametersBuilder.Append(' ');
                requestParametersBuilder.Append($"Body: {body}");
                request.Body.Position = 0;
            }
            else if (request.ContentLength > MaxBodyLength)
            {
                requestParametersBuilder.Append($"Body to large to be buffered. Limit set to 30k bytes cause performance reason.");
            }
            
            var exceptionResult = JsonSerializer.Serialize(new BmsResponse
            {
                ApplicationError = exception.Message
            });
            context.Response.ContentType = ContentType;
            context.Response.StatusCode = (int)status;
            _logger.LogError(exception,
                "{RequesuestMethod}{Route}{QueryParameters}{UserPermissions}"
                , request.Method, request.Path, requestParametersBuilder.ToString(), string.Empty);
            await context.Response.WriteAsync(exceptionResult);
        }
    }
}

