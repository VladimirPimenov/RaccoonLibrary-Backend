using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Text.Encodings.Web;
using System.Text.Json;

namespace RaccoonLibrary.Bookshelf.Middlewares
{
	public class ExceptionMiddleware(RequestDelegate next)
	{
		public async Task Invoke(HttpContext httpContext)
		{
			try
			{
				await next(httpContext);
			}
			catch(DbUpdateException ex)
			{
				await HandleException(httpContext, HttpStatusCode.Conflict, "Такой автор/жанр уже задан для книги");
			}
			catch(Exception ex)
			{
				await HandleException(httpContext, HttpStatusCode.InternalServerError, "Произошла непредвиденная ошибка: " + ex.Message);
			}
		}

		private async Task HandleException(
			HttpContext httpContext,
			HttpStatusCode statusCode,
			string message)
		{
			HttpResponse response = httpContext.Response;

			response.ContentType = "application/json";
			response.StatusCode = (int)statusCode;

			JsonSerializerOptions option = new JsonSerializerOptions
			{
				Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
			};

			string errorMessage = JsonSerializer.Serialize(message, option);

			await response.WriteAsJsonAsync(errorMessage);
		}
	}
}
