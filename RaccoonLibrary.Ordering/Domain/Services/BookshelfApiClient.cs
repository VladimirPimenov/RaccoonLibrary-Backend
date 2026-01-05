using RaccoonLibrary.Ordering.Domain.Contracts;
using RaccoonLibrary.Ordering.Domain.Entities;

namespace RaccoonLibrary.Ordering.Domain.Services
{
	public class BookshelfApiClient(
		IHttpClientFactory httpClientFactory,
		IConfiguration config)
		: IBookshelfApiClient
	{
		private readonly string _bookshelfApiAddress = config.GetValue<string>("ServiceConnections:BookshelfService");

		public async Task<Book> GetBookByIdAsync(int id)
		{
			string requestString = $"{_bookshelfApiAddress}/book/{id}";

			HttpClient httpClient = httpClientFactory.CreateClient();
			using HttpResponseMessage responce = await httpClient.GetAsync(requestString);

			if (responce.StatusCode != System.Net.HttpStatusCode.OK)
				return null;

			Book book = await responce.Content.ReadFromJsonAsync<Book>();

			return book;
		}
	}
}
