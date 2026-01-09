using RaccoonLibrary.Ordering.Domain.Entities;

namespace RaccoonLibrary.Ordering.Domain.Contracts
{
	/// <summary>
	/// Определяет методы для взаимодействия с API сервиса ReaderLibrary.
	/// </summary>
	public interface ICustomerLibraryApiClient
	{
		/// <summary>
		/// Добавляет книгу в библиотеку клиента.
		/// </summary>
		/// <param name="book">Объект книги для добавления.</param>
		/// <param name="customerId">Идентификатор клиента.</param>
		/// <returns>True, если книга успешно добавлена, иначе False.</returns>
		public Task<bool> AddBookToCustomerAsync(Book book, int customerId);

		/// <summary>
		/// Проверяет, находится ли книга в библиотеке клиента.
		/// </summary>
		/// <param name="book">Объект книги для проверки.</param>
		/// <param name="customerId">Идентификатор клиента.</param>
		/// <returns>True, если книга уже в библиотеке, иначе False.</returns>
		public Task<bool> IsBookAlreadyInCustomerLibrary(Book book, int customerId);
	}
}
