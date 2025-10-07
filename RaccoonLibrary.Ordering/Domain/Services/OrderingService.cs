using RaccoonLibrary.Ordering.Domain.Contracts;
using RaccoonLibrary.Ordering.Domain.Entities;
using RaccoonLibrary.Ordering.Domain.Repositories;

namespace RaccoonLibrary.Ordering.Domain.Services
{
	public class OrderingService(
		IOrderRepository orderRepository,
		IBookshelfService bookService)
		: IOrderingService
	{
		public async Task AddBookToCustomerOrderAsync(int bookId, int customerId)
		{
			Book book = await bookService.GetBookByIdAsync(bookId);

			Order order = await orderRepository.GetCustomerOrderAsync(customerId);

			if(order == null)
			{
				order = await orderRepository.AddOrderAsync(new Order { CustomerId = customerId });
			}

			order.OrderPrice += book.Price;

			await orderRepository.UpdateOrderAsync(order);

			await orderRepository.AddBookToOrderAsync(book.BookId, order.OrderId);
		}

		public async Task<Order> GetCustomerOrderAsync(int customerId)
		{
			Order order = await orderRepository.GetCustomerOrderAsync(customerId);

			if (order != null)
				order.OrderedBooks = await GetOrderBooks(order);

			return order;
		}

		public async Task<int> RemoveOrderAsync(Order order)
		{
			return await orderRepository.RemoveOrderAsync(order);
		}

		public async Task RemoveBookFromCustomerOrderAsync(int bookId, int customerId)
		{
			Order order = await orderRepository.GetCustomerOrderAsync(customerId);

			Book book = await bookService.GetBookByIdAsync(bookId);

			if (order != null)
				order.OrderPrice -= book.Price;

			await orderRepository.RemoveBookFromOrderAsync(bookId, order.OrderId);

			await RemoveOrderIfNoBooks(order);
		}

		private async Task<List<Book>> GetOrderBooks(Order order)
		{
			var bookIds = await orderRepository.GetOrderBookIdsAsync(order.OrderId);

			return await bookService.GetBookListByIdsAsync(bookIds);
		}

		private async Task RemoveOrderIfNoBooks(Order order)
		{
			int booksInOrder = await orderRepository.CountOrderBooksAsync(order);

			if (booksInOrder == 0)
				await RemoveOrderAsync(order);
		}
	}
}
