using RaccoonLibrary.Bookshelf.Domain.Entities;

namespace RaccoonLibrary.Bookshelf.Domain.Contracts
{
	public interface ISearchService
	{
		public Task<List<Book>> FindBooksByQueryAsync(string query);

		public Task<List<Author>> FindAuthorsAsync(string lastName);
	}
}
