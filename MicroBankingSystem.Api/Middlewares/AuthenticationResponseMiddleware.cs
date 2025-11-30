using MicroBankingSystem.domain.ResponseHelper;

namespace MicroBankingSystem.Api.Middlewares
{
    public class AuthenticationResponseMiddleware(RequestDelegate _next)
    {
        public async Task InvokeAsync(HttpContext context)
        {
            await _next(context);

            if (context.Response.StatusCode == StatusCodes.Status401Unauthorized && !context.Response.HasStarted)
            {
                context.Response.ContentType = "application/json";
                var respnse = new ApiResponse<object>(
                     401,
                    "Authentication failed. Please provide a valid token.",
                    null
                    );
                await context.Response.WriteAsJsonAsync(respnse);
            }
            else if (context.Response.StatusCode == StatusCodes.Status403Forbidden && !context.Response.HasStarted)
            {
                context.Response.ContentType = "application/json";
                var respnse = new ApiResponse<object>(
                     403,
                     "Unuthorized access.",
                    null
                    );
                await context.Response.WriteAsJsonAsync(respnse);
            }

        }
    }
}
