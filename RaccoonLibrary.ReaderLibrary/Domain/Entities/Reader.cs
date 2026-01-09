namespace RaccoonLibrary.ReaderLibrary.Domain.Entities
{
	/// <summary>
	/// Представляет читателя.
	/// </summary>
	public class Reader
	{
		/// <summary>
		/// Уникальный идентификатор читателя.
		/// </summary>
		public int ReaderId { get; set; }

		/// <summary>
		/// Адрес электронной почты.
		/// </summary>
		public string Email { get; set; }
	}
}
