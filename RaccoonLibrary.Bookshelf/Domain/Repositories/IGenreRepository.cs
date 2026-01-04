using RaccoonLibrary.Bookshelf.Domain.Entities;

namespace RaccoonLibrary.Bookshelf.Domain.Repositories
{
	public interface IGenreRepository
	{
		public Task<Genre> GetGenreByIdAsync(int id);

		public Task<Genre> CreateGenreAsync(Genre genre);

		public Task<int> RemoveGenreAsync(Genre genre);
	}
}
