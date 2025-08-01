using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Tywynh.Domain.Interfaces;
using Tywynh.Domain.Models;
using System;

namespace Tywynh.API.Middleware
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestLoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, ILogRepository logRepository)
        {
            var log = new RequestLog
            {
                IpAddress = context.Connection.RemoteIpAddress?.ToString(),
                UserAgent = context.Request.Headers["User-Agent"].ToString(),
                Path = context.Request.Path,
                Method = context.Request.Method,
                Timestamp = DateTime.UtcNow
            };

            await logRepository.AddAsync(log);

            await _next(context);
        }
    }
}