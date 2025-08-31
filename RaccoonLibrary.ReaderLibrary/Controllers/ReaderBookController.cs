using Microsoft.AspNetCore.Mvc;
using RaccoonLibrary.ReaderLibrary.Domain.Contracts;
using RaccoonLibrary.ReaderLibrary.Domain.DTO;

namespace RaccoonLibrary.ReaderLibrary.Controllers
{
	[Route("/reader")]
	[ApiController]
	public class ReaderBookController(
		IReaderBooksService booksService)
		: ControllerBase
	{
		[HttpGet("{readerId}")]
		public async Task<IActionResult> GetReaderBooksAsync(int readerId)
		{
			var books = await booksService.GetReaderBooksAsync(readerId);

			return Ok(books);
		}

		[HttpPost]
		public async Task<IActionResult> AddBookToReaderAsync(BookAddingRequest request)
		{
			var addedBook = await booksService.AddBookToReaderAsync(request);

			return addedBook == null ? BadRequest() : Ok(addedBook);
		}

	}
}
