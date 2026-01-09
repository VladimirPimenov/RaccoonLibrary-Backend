namespace RaccoonLibrary.Bookshelf.Domain.Entities
{
	/// <summary>
	/// Представляет автора книги.
	/// </summary>
	public class Author
	{
		/// <summary>
		/// Уникальный идентификатор автора.
		/// </summary>
		public int AuthorId { get;set; }

		/// <summary>
		/// Имя автора.
		/// </summary>
		public string FirstName { get; set; }

		/// <summary>
		/// Фамилия автора.
		/// </summary>
		public string LastName { get; set; }
	}
}
