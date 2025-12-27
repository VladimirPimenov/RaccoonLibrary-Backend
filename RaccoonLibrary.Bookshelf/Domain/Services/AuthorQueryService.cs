using RaccoonLibrary.Bookshelf.Domain.Contracts;
using RaccoonLibrary.Bookshelf.Domain.Entities;
using RaccoonLibrary.Bookshelf.Domain.Repositories;

namespace RaccoonLibrary.Bookshelf.Domain.Services
{
	public class AuthorQueryService(
		IAuthorRepository authorRepository) 
		: IAuthorQueryService
	{
		public async Task<Author> GetAuthorAsync(int authorId)
		{
			return await authorRepository.GetAuthorByIdAsync(authorId);
		}
	}
}
