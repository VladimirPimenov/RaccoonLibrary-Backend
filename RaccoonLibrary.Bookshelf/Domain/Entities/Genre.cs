namespace RaccoonLibrary.Bookshelf.Domain.Entities
{
	/// <summary>
	/// Представляет жанр книги.
	/// </summary>
	public class Genre
	{
		/// <summary>
		/// Уникальный идентификатор жанра.
		/// </summary>
		public int GenreId { get; set; }

		/// <summary>
		/// Название жанра.
		/// </summary>
		public string Name { get; set; }
	}
}
