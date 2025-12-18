using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Text.Encodings.Web;
using System.Text.Json;

namespace RaccoonLibrary.ReaderLibrary.Middlewares
{
	public class ExceptionMiddleware(RequestDelegate next)
	{
		public async Task InvokeAsync(HttpContext httpContext)
		{
			try
			{
				await next.Invoke(httpContext);
			}
			catch(DbUpdateException ex)
			{
				await HandleExceptionAsync(httpContext, HttpStatusCode.Conflict, "Книга уже приобретена");
			}
			catch(Exception ex)
			{
				await HandleExceptionAsync(httpContext, HttpStatusCode.InternalServerError, "Произошла неизвестная ошибка");
			}
		}

		private async Task HandleExceptionAsync(
			HttpContext httpContext,
			HttpStatusCode statusCode,
			string message)
		{
			HttpResponse response = httpContext.Response;
			response.ContentType = "application/json";
			response.StatusCode = (int)statusCode;

			JsonSerializerOptions options = new JsonSerializerOptions
			{
				Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
				WriteIndented = true
			};

			string errorMessage = JsonSerializer.Serialize(new { Message = message }, options);

			await response.WriteAsJsonAsync(errorMessage);
		}
	}
}
