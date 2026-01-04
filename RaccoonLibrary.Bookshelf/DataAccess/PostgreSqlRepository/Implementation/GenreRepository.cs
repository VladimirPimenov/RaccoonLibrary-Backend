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

		public async Task<Genre> CreateGenreAsync(Genre genre)
		{
			context.Genre.Add(genre);
			await context.SaveChangesAsync();

			return genre;
		}

		public async Task<int> RemoveGenreAsync(Genre genre)
		{
			context.Genre.Remove(genre);
			await context.SaveChangesAsync();

			return genre.GenreId;
		}
	}
}
