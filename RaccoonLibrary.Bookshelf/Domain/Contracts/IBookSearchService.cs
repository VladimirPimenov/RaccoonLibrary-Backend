using RaccoonLibrary.Bookshelf.Domain.Entities;
using RaccoonLibrary.Bookshelf.Domain.Enums;

namespace RaccoonLibrary.Bookshelf.Domain.Contracts
{
	public interface IBookSearchService
	{
		public Task<List<Book>> FindBooksByQueryAsync(string query, SearchType searchType);
	}
}
