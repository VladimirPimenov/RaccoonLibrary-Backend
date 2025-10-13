using RaccoonLibrary.Ordering.Domain.Contracts;
using RaccoonLibrary.Ordering.Domain.DTO;
using RaccoonLibrary.Ordering.Domain.Entities;

namespace RaccoonLibrary.Ordering.Domain.Services
{
	public class CustomerLibraryApiClient
	(
		IHttpClientFactory httpClientFactory,
		IConfiguration config)
		: ICustomerLibraryApiClient
	{
		private readonly string libraryApiAddress = config.GetValue<string>("ServiceConnections:LibraryService");

		public async Task AddOrderedBooksToCustomerAsync(Order order)
		{
			foreach(var book in order.OrderedBooks)
			{
				await AddBookToCustomerAsync(book.BookId, order.CustomerId);
			}
		}

		private async Task AddBookToCustomerAsync(int bookId, int customerId)
		{
			string requestString = $"{libraryApiAddress}";

			var content = new BookAddingRequest
			{
				BookId = bookId,
				ReaderId = customerId
			};

			HttpClient httpClient = httpClientFactory.CreateClient();
			using HttpResponseMessage responce = await httpClient.PostAsJsonAsync(requestString, content);
		}
	}
}
