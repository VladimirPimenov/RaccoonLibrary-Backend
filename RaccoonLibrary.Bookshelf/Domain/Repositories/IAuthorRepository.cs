using RaccoonLibrary.Bookshelf.Domain.Entities;

namespace RaccoonLibrary.Bookshelf.Domain.Repositories
{
	public interface IAuthorRepository
	{
		public Task<Author> GetAuthorByIdAsync(int id);

		public Task<Author> CreateAuthorAsync(Author author);

		public Task<int> RemoveAuthorAsync(Author author);
	}
}
