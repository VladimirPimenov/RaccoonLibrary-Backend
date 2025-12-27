using RaccoonLibrary.Bookshelf.Domain.Entities;
using RaccoonLibrary.Bookshelf.Domain.Repositories;

namespace RaccoonLibrary.Bookshelf.DataAccess.PostgreSqlRepository.Implementation
{
	public class GenreRepository(
		PostgreSqlDbContext context)
		: IGenreRepository
	{
		public async Task<Genre> GetGenreByIdAsync(int id)
		{
			return await context.Genre.FindAsync(id);
		}
	}
}
