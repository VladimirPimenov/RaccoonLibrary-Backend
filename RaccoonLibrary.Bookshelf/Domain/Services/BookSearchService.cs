using RaccoonLibrary.Bookshelf.Domain.Entities;
using RaccoonLibrary.Bookshelf.Domain.Enums;

using RaccoonLibrary.Bookshelf.Domain.Contracts;
using RaccoonLibrary.Bookshelf.Domain.Repositories;

namespace RaccoonLibrary.Bookshelf.Domain.Services
{
	public class BookSearchService(
		IBookSearchRepository searchRepository)
		: IBookSearchService
	{
		public async Task<List<Book>> FindBooksByQueryAsync(string query, SearchType searchType)
		{
			var searchPattern = $"%{query.ToLower()}%";
			var searchResults = new List<Book>();

			switch (searchType)
			{
				case SearchType.General:
					searchResults = await FindCardsByGeneralQuery(searchPattern);
					break;
				case SearchType.BookTitle:
					searchResults = await searchRepository.FindBooksByTitleAsync(searchPattern);
					break;
				case SearchType.AuthorLastName:
					searchResults = await searchRepository.FindBooksByAuthorAsync(searchPattern);
					break;
				case SearchType.PublisherName:
					searchResults = await searchRepository.FindBooksByPublisherAsync(searchPattern);
					break;
				case SearchType.GenreName:
					searchResults = await searchRepository.FindBooksByGenreAsync(searchPattern);
					break;
			}

			return searchResults;
		}

		private async Task<List<Book>> FindCardsByGeneralQuery(string searchPattern)
		{
			return new List<Book>()
						.Concat(await searchRepository.FindBooksByTitleAsync(searchPattern))
						.Concat(await searchRepository.FindBooksByAuthorAsync(searchPattern))
						.Concat(await searchRepository.FindBooksByPublisherAsync(searchPattern))
						.Concat(await searchRepository.FindBooksByGenreAsync(searchPattern))
						.Distinct()
						.ToList();
		}
	}
}
