using RaccoonLibrary.Bookshelf.Domain.Entities;

namespace RaccoonLibrary.Bookshelf.Domain.Repositories
{
	public interface ISearchRepository
	{
		public Task<List<Book>> FindBooksByTitleAsync(string title);

		public Task<List<Book>> FindBooksByAuthorAsync(string authorLastName);

		public Task<List<Book>> FindBooksByGenreAsync(string genreName);

		public Task<List<Author>> FindAuthorByLastName(string lastName);
	}
}
