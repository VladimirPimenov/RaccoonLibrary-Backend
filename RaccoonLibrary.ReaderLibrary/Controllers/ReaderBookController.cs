using Microsoft.AspNetCore.Mvc;
using RaccoonLibrary.ReaderLibrary.Domain.Contracts;

namespace RaccoonLibrary.ReaderLibrary.Controllers
{
	[Route("/reader")]
	[ApiController]
	public class ReaderBookController(
		IReaderBooksService booksService)
		: ControllerBase
	{
		[HttpGet("{readerId}")]
		public async Task<IActionResult> GetReaderBooks(int readerId)
		{
			var books = await booksService.GetReaderBooksAsync(readerId);

			return Ok(books);
		}
	}
}
