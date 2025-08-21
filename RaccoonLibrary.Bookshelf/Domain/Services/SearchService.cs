using RaccoonLibrary.Bookshelf.Domain.Entities;
using RaccoonLibrary.Bookshelf.Domain.DTO;
using RaccoonLibrary.Bookshelf.Domain.Mappers;

using RaccoonLibrary.Bookshelf.Domain.Repositories;

using RaccoonLibrary.Bookshelf.Domain.Contracts;

namespace RaccoonLibrary.Bookshelf.Domain.Services
{
	public class SearchService(
		ISearchRepository searchRepository)
		: ISearchService
	{
		public async Task<List<BookDto>> FindBooksByQueryAsync(string query)
		{
			var searchPattern = $"%{query.ToLower()}%";

			var foundedBooks = new List<Book>()
									.Concat(await searchRepository.FindBooksByTitleAsync(searchPattern))
									.Concat(await searchRepository.FindBooksByAuthorAsync(searchPattern))
									.Concat(await searchRepository.FindBooksByGenreAsync(searchPattern))
									.Distinct()
									.ToList();

			var bookDTOs = BookMapper.ConvertEntitiesToDtoList(foundedBooks);

			return bookDTOs;
		}

		public async Task<List<Author>> FindAuthorsAsync(string lastName)
		{
			var searchPattern = $"%{lastName.ToLower()}%";

			return await searchRepository.FindAuthorByLastName(searchPattern);
		}
	}
}
