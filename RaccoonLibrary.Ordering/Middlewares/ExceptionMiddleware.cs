using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace RaccoonLibrary.Ordering.Middlewares
{
	public class ExceptionMiddleware(RequestDelegate next)
	{
		public async Task InvokeAsync(HttpContext httpContext)
		{
			try
			{
				await next(httpContext);
			}
			catch (DbUpdateException ex)
			{
				await HandleExceptionAsync(httpContext, HttpStatusCode.Conflict, "Книга уже в заказе");
			}
			catch (Exception ex)
			{
				await HandleExceptionAsync(httpContext, HttpStatusCode.InternalServerError, "Произошла неизвестная ошибка");
			}
		}

		private async Task HandleExceptionAsync(
			HttpContext httpContext, 
			HttpStatusCode statusCode,
			string message)
		{
			HttpResponse responce = httpContext.Response;

			responce.ContentType = "application/json";
			responce.StatusCode = (int)statusCode;

			JsonSerializerOptions options = new JsonSerializerOptions
			{
				Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
				WriteIndented = true
			};

			string errorMessage = JsonSerializer.Serialize(new { Message = message }, options);

			await responce.WriteAsJsonAsync(errorMessage);
		}
	}
}
