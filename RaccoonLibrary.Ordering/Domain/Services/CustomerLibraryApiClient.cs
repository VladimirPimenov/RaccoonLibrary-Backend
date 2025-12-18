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

		public async Task<bool> AddOrderedBooksToCustomerAsync(Order order)
		{
			foreach(var book in order.OrderedBooks)
			{
				bool isBookAdded = await AddBookToCustomerAsync(book.BookId, order.CustomerId);

				if(!isBookAdded)
					return false;
			}
			return true;
		}

		public async Task<bool> IsBookAlreadyInCustomerLibrary(Book book, int customerId)
		{
			string requestString = $"{libraryApiAddress}/{customerId}/books/{book.BookId}";

			HttpClient httpClient = httpClientFactory.CreateClient();
			using HttpResponseMessage response = await httpClient.GetAsync(requestString);

			if (response.StatusCode == System.Net.HttpStatusCode.OK)
				return true;
			return false;
		}

		private async Task<bool> AddBookToCustomerAsync(int bookId, int customerId)
		{
			var content = new BookAddingRequest
			{
				BookId = bookId,
				ReaderId = customerId
			};

			HttpClient httpClient = httpClientFactory.CreateClient();
			using HttpResponseMessage response = await httpClient.PostAsJsonAsync(libraryApiAddress, content);

			if (response.StatusCode != System.Net.HttpStatusCode.OK)
				return false;
			return true;
		}
	}
}
