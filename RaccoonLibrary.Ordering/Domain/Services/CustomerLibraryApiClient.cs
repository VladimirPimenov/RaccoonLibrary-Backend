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
		private readonly string _libraryApiAddress = config.GetValue<string>("ServiceConnections:LibraryService");

		public async Task<bool> AddBookToCustomerAsync(Book book, int customerId)
		{
			var content = new BookAddingRequest
			{
				BookId = book.BookId,
				ReaderId = customerId
			};

			HttpClient httpClient = httpClientFactory.CreateClient();
			using HttpResponseMessage response = await httpClient.PostAsJsonAsync(_libraryApiAddress, content);

			if (response.StatusCode != System.Net.HttpStatusCode.OK)
				return false;
			return true;
		}

		public async Task<bool> IsBookAlreadyInCustomerLibrary(Book book, int customerId)
		{
			string requestString = $"{_libraryApiAddress}/{customerId}/books/{book.BookId}";

			HttpClient httpClient = httpClientFactory.CreateClient();
			using HttpResponseMessage response = await httpClient.GetAsync(requestString);

			if (response.StatusCode == System.Net.HttpStatusCode.OK)
				return true;
			return false;
		}
	}
}
