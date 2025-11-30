using MicroBankingSystem.domain.Exceptions;
using MicroBankingSystem.domain.ResponseHelper;
using UnauthorizedAccessException = MicroBankingSystem.domain.Exceptions.UnauthorizedAccessException;

namespace MicroBankingSystem.Api.Middlewares
{
    public class CustomeExeptionHandler(RequestDelegate _next,ILogger<CustomeExeptionHandler> _logger)
    {
        public async Task InvokeAsync(HttpContext context )
        {
			try
			{
				await _next.Invoke(context);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "An unhandled exception has occurred.");
				await HandleExceptionAsync(context, ex);
            }
        }

		private async Task HandleExceptionAsync(HttpContext context, Exception ex)
		{
			string message = ex.Message;
			int statusCode = ex switch
			{
				BadRequestException => StatusCodes.Status400BadRequest,
				UnauthorizedAccessException => StatusCodes.Status401Unauthorized,
				ForbiddenException => StatusCodes.Status403Forbidden,
                NotFoundException => StatusCodes.Status404NotFound,
				ConflictException => StatusCodes.Status409Conflict,
				FailedException => StatusCodes.Status500InternalServerError,
                _ => StatusCodes.Status500InternalServerError
            };

			context.Response.ContentType = "application/json";
			context.Response.StatusCode = statusCode;
			var response = new ApiResponse<object>(statusCode, message);
            await context.Response.WriteAsJsonAsync(response);


        }



	}
}
