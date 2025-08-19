using Microsoft.AspNetCore.Mvc;

using RaccoonLibrary.Bookshelf.Domain.Enums;
using RaccoonLibrary.Bookshelf.Domain.Contracts;

namespace RaccoonLibrary.Bookshelf.Controllers
{
	[Route("/catalog")]
	[ApiController]
	public class CatalogController(
		IBookSearchService searchService)
		: ControllerBase
	{
		[HttpGet("{searchType}")]
		public async Task<IActionResult> SearchBookCardsByQueryAsync(
			SearchType searchType,
			[FromQuery] string query)
		{
			if (query == null)
				return BadRequest();

			var searchResults = await searchService.FindBooksByQueryAsync(query, searchType);

			return Ok(searchResults);
		}
	}
}
