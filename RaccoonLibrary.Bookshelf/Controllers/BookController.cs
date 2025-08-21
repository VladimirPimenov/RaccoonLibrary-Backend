using Microsoft.AspNetCore.Authorization;
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
			throw new NotImplementedException();
		}
	}
}
