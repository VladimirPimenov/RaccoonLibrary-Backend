using RaccoonLibrary.Ordering.Domain.Contracts;
using RaccoonLibrary.Ordering.Domain.Entities;

namespace RaccoonLibrary.Ordering.Domain.Services
{
	public class BookshelfApiClient(
		IHttpClientFactory httpClientFactory,
		IConfiguration config)
		: IBookshelfApiClient
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

		public async Task<List<Book>> GetBookListByIdsAsync(List<int> ids)
		{
			var books = new List<Book>();

			foreach(int id in ids)
			{
				var book = await GetBookByIdAsync(id);

				if(book != null)
					books.Add(book);
			}

			return books;
		}
	}
}
