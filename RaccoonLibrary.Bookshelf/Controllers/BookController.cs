using Microsoft.AspNetCore.Mvc;

using RaccoonLibrary.Bookshelf.Domain.Contracts;

namespace RaccoonLibrary.Bookshelf.Controllers
{
	[Route("/book")]
	[ApiController]
	public class BookController(
		IBookQueryService bookService) 
		: ControllerBase
	{
		[HttpGet]
		public async Task<IActionResult> GetBook(int bookId)
		{
			var book = await bookService.GetBook(bookId);

			return book == null ? NotFound() : Ok(book);
		}
	}
}
