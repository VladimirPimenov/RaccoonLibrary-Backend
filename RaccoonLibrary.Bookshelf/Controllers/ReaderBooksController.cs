using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using RaccoonLibrary.Bookshelf.Domain.Contracts;

namespace RaccoonLibrary.Bookshelf.Controllers
{
	[Route("/books")]
	[ApiController]
	public class ReaderBooksController(
		IReaderBooksService booksService) 
		: ControllerBase
	{
		[HttpGet]
		public async Task<IActionResult> GetReaderBooksAsync(int readerId)
		{
			var books = await booksService.GetReaderBooksAsync(readerId);

			return Ok(books);
		}
	}
}
