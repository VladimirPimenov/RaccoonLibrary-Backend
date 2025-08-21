using Microsoft.AspNetCore.Mvc;

using RaccoonLibrary.Bookshelf.Domain.Contracts;

namespace RaccoonLibrary.Bookshelf.Controllers
{
	[Route("/search")]
	[ApiController]
	public class SearchController(
		ISearchService searchService)
		: ControllerBase
	{
		[HttpGet("books")]
		public async Task<IActionResult> SearchBooksByQueryAsync(string query)
		{
			if (query == null)
				return BadRequest();

			var books = await searchService.FindBooksByQueryAsync(query);

			return Ok(books);
		}

		[HttpGet("authors")]
		public async Task<IActionResult> SearchAuthorByNameAsync(string query)
		{
			if(query == null)
				return BadRequest();

			var authors = await searchService.FindAuthorsAsync(query);

			return Ok(authors);
		}
	}
}
