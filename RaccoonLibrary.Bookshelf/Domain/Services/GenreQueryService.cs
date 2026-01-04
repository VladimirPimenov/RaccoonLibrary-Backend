using RaccoonLibrary.Bookshelf.Domain.Contracts;
using RaccoonLibrary.Bookshelf.Domain.Entities;
using RaccoonLibrary.Bookshelf.Domain.Repositories;

namespace RaccoonLibrary.Bookshelf.Domain.Services
{
	public class GenreQueryService(
		IGenreRepository genreRepository)
		: IGenreQueryService
	{
		public async Task<Genre> CreateGenreAsync(Genre genre)
		{
			var newGenre = await genreRepository.CreateGenreAsync(genre);

			return newGenre;
		}

		public async Task<int?> RemoveGenreAsync(int genreId)
		{
			Genre genre = await genreRepository.GetGenreByIdAsync(genreId);

			if (genre == null)
				return null;

			int removedGenreId = await genreRepository.RemoveGenreAsync(genre);

			return removedGenreId;
		}
	}
}
