using Domain.Exceptions;
using Shared.ErrorModels;
using System.ComponentModel.DataAnnotations;
using System.Net;
using ValidationException = Domain.Exceptions.ValidationException;

namespace SchoolMAnagementSystem.Api.MiddleWares
{
	public class ExceptionHandlerMiddleware(RequestDelegate next, ILogger<ExceptionHandlerMiddleware> logger)
	{
		public async Task InvokeAsync(HttpContext context)
		{
			try
			{
				await next.Invoke(context);
				// If the response status code is 404, it means the endpoint was not found
				// If can't invoke the next func, it means the endpoint was not found
				if (context.Response.StatusCode == (int)HttpStatusCode.NotFound)
					await HandleNotFoundEndPointException(context);
			}
			catch (Exception ex)
			{
				logger.LogError(ex, $"Something went wrong -> {ex.Message}");
				await HandleException(context, ex);
			}
		}

		private static async Task HandleException(HttpContext context, Exception ex)
		{
			// 1 -> Create Error Object
			ErrorDto error = new ErrorDto();

			// 2 -> Set Status Code (For Context)
			context.Response.StatusCode = ex switch
			{
				NotFoundException => (int)HttpStatusCode.NotFound,
				ValidationException validationException => ValidationHandle(validationException, error),
				UnAuthorizedException => (int)HttpStatusCode.Unauthorized,
				_ => (int)HttpStatusCode.InternalServerError,
			};

			// 3 -> Assign Status Code & Message (For Return Error Model)
			error.StatusCode = context.Response.StatusCode;
			error.Message = $"Error Message -> {ex.Message}";

			// 4 -> Serialize & Return
			await context.Response.WriteAsJsonAsync(error);
		}

		private static int ValidationHandle(ValidationException validationException, ErrorDto error)
		{
			error.Errors = validationException.Errors;
			return (int)HttpStatusCode.BadRequest;
		}

		private static async Task HandleNotFoundEndPointException(HttpContext context)
		{
			ErrorDto error = new ErrorDto()
			{
				StatusCode = context.Response.StatusCode,
				Message = $"Error Message -> Not Found End Point With Path {context.Request.Path}",
			};
			await context.Response.WriteAsJsonAsync(error);
		}
	}
}
