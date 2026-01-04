using RaccoonLibrary.Bookshelf.Domain.Entities;

namespace RaccoonLibrary.Bookshelf.Domain.Contracts
{
	public interface IAuthorQueryService
	{
		public Task<Author> GetAuthorAsync(int authorId);

		public Task<Author> CreateAuthorAsync(Author author);

		public Task<int?> RemoveAuthorAsync(int id);
	}
}
