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

		public async Task<Author> CreateAuthorAsync(Author author)
		{
			Author newAuthor = await authorRepository.CreateAuthorAsync(author);

			return newAuthor;
		}

		public async Task<int?> RemoveAuthorAsync(int authorId)
		{
			Author author = await authorRepository.GetAuthorByIdAsync(authorId);

			if (author == null)
				return null;

			int removedAuthorId = await authorRepository.RemoveAuthorAsync(author);

			return removedAuthorId;
		}
	}
}
