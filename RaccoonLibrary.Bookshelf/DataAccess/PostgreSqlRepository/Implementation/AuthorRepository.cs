using RaccoonLibrary.Bookshelf.Domain.Entities;
using RaccoonLibrary.Bookshelf.Domain.Repositories;

namespace RaccoonLibrary.Bookshelf.DataAccess.PostgreSqlRepository.Implementation
{
	public class AuthorRepository(
		PostgreSqlDbContext context)
		: IAuthorRepository
	{
		public async Task<Author> GetAuthorById(int id)
		{
			return await context.Author.FindAsync(id);
		}
	}
}
