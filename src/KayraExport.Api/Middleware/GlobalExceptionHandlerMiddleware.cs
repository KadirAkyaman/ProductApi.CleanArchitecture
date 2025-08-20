using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using KayraExport.Application.Exceptions;

namespace KayraExport.Api.Middleware
{
    public class GlobalExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalExceptionHandlerMiddleware> _logger;

        public GlobalExceptionHandlerMiddleware(RequestDelegate next, ILogger<GlobalExceptionHandlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unexpected error occurred: {ErrorMessage}", ex.Message);

                context.Response.ContentType = "application/json";
                var response = new { Message = ex.Message };

                switch (ex)
                {
                    case NotFoundException:
                        context.Response.StatusCode = (int)HttpStatusCode.NotFound; // 404
                        break;
                    default:
                        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError; // 500
                        response = new { Message = "An unexpected error occurred on the server." }; // General message
                        break;
                }

                await context.Response.WriteAsync(JsonSerializer.Serialize(response));
            }
        }
    }
}