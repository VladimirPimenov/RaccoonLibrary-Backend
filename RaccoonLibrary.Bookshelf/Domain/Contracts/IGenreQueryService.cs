using RaccoonLibrary.Bookshelf.Domain.Entities;

namespace RaccoonLibrary.Bookshelf.Domain.Contracts
{
	public interface IGenreQueryService
	{
		public Task<Genre> CreateGenreAsync(Genre genre);

		public Task<int?> RemoveGenreAsync(int id);
	}
}
