using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace BankingManagmentSystem.Middlewares
{
	public class ApplicationErrorHandlingMiddleware
	{
		private readonly RequestDelegate _next;

		public ApplicationErrorHandlingMiddleware(RequestDelegate next)
		{
			_next = next;
		}

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            HttpStatusCode status;

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


            var exceptionResult = JsonSerializer.Serialize(new { error = exception.Message, exception.StackTrace });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)status;

            return context.Response.WriteAsync(exceptionResult);
        }
    }
}

