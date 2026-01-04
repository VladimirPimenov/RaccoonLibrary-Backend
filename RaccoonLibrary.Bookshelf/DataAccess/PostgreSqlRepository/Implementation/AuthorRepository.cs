using RaccoonLibrary.Bookshelf.Domain.Entities;
using RaccoonLibrary.Bookshelf.Domain.Repositories;

namespace RaccoonLibrary.Bookshelf.DataAccess.PostgreSqlRepository.Implementation
{
	public class AuthorRepository(
		PostgreSqlDbContext context)
		: IAuthorRepository
	{
		public async Task<Author> GetAuthorByIdAsync(int id)
		{
			return await context.Author.FindAsync(id);
		}

		public async Task<Author> CreateAuthorAsync(Author author)
		{
			context.Author.Add(author);
			await context.SaveChangesAsync();

			return author;
		}

		public async Task<int> RemoveAuthorAsync(Author author)
		{
			context.Author.Remove(author);
			await context.SaveChangesAsync();

			return author.AuthorId;
		}
	}
}
