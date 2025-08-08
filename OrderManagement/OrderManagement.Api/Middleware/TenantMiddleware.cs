using OrderManagement.Application.Interfaces;

namespace OrderManagement.Api.Middleware
{
    public class TenantMiddleware
    {
        private readonly RequestDelegate _next;

        public TenantMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, ITenantProvider tenantProvider)
        {
            if (context.Request.RouteValues.TryGetValue("tenantId", out var tenantValue)
                && int.TryParse(tenantValue?.ToString(), out var tenantId))
            {
                tenantProvider.TenantId = tenantId;
                await _next(context);
            }
            else
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync("Invalid or missing tenant ID.");
            }
        }
    }
}