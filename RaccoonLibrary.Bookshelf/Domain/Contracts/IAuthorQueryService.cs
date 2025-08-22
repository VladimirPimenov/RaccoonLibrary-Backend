using RaccoonLibrary.Bookshelf.Domain.Entities;

namespace RaccoonLibrary.Bookshelf.Domain.Contracts
{
	public interface IAuthorQueryService
	{
		public Task<Author> GetAuthor(int authorId);
	}
}
