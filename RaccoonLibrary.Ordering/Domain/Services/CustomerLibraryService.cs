using RaccoonLibrary.Ordering.Domain.Contracts;
using RaccoonLibrary.Ordering.Domain.DTO;
using RaccoonLibrary.Ordering.Domain.Entities;

namespace RaccoonLibrary.Ordering.Domain.Services
{
	public class CustomerLibraryService(
		IHttpClientFactory httpClientFactory,
		IConfiguration config)
		: ICustomerLibraryService
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
			string requestString = $"{libraryApiAddress}/reader";

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
