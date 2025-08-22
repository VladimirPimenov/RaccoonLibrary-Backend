using RaccoonLibrary.Bookshelf.Domain.Entities;

namespace RaccoonLibrary.Bookshelf.Domain.Repositories
{
	public interface IAuthorRepository
	{
		public Task<Author> GetAuthorById(int id);
	}
}
