using RaccoonLibrary.Bookshelf.Domain.Entities;

namespace RaccoonLibrary.Bookshelf.Domain.Repositories
{
	public interface IGenreRepository
	{
		public Task<Genre> GetGenreByIdAsync(int id);
	}
}
