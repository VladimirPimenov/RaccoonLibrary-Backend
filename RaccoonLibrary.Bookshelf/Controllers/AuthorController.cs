using Microsoft.AspNetCore.Mvc;

using RaccoonLibrary.Bookshelf.Domain.Contracts;

namespace RaccoonLibrary.Bookshelf.Controllers
{
	[Route("author")]
	[ApiController]
	public class AuthorController(
		IAuthorQueryService authorService)
		: ControllerBase
	{
		[HttpGet]
		public async Task<IActionResult> GetAuthor(int authorId)
		{
			var author = await authorService.GetAuthor(authorId);

			return author == null ? NotFound() : Ok(author);
		}
	}
}
