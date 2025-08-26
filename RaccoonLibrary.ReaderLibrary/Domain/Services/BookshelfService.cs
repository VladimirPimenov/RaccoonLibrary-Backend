using RaccoonLibrary.ReaderLibrary.Domain.Contracts;
using RaccoonLibrary.ReaderLibrary.Domain.Entities;

namespace RaccoonLibrary.ReaderLibrary.Domain.Services
{
	public class BookshelfService(
		IHttpClientFactory httpClientFactory,
		IConfiguration config) 
		: IBookshelfService
	{
		private readonly string bookshelfApiAddress = config.GetValue<string>("ServiceConnections:BookshelfService");

		public async Task<Book> GetBookByIdAsync(int id)
		{
			string requestString = $"{bookshelfApiAddress}/book/{id}";

			HttpClient httpClient = httpClientFactory.CreateClient();
			using HttpResponseMessage responce = await httpClient.GetAsync(requestString);

			if (responce.StatusCode == System.Net.HttpStatusCode.NotFound)
				return null;

			Book book = await responce.Content.ReadFromJsonAsync<Book>();

			return book;
		}
	}
}
