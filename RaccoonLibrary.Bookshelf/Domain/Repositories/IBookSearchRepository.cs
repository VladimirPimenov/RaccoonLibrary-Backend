using RaccoonLibrary.Bookshelf.Domain.Entities;

namespace RaccoonLibrary.Bookshelf.Domain.Repositories
{
	public interface IBookSearchRepository
	{
		public Task<List<Book>> FindBooksByTitleAsync(string title);

		public Task<List<Book>> FindBooksByAuthorAsync(string authorLastName);

		public Task<List<Book>> FindBooksByPublisherAsync(string publisherName);

		public Task<List<Book>> FindBooksByGenreAsync(string genreName);
	}
}
