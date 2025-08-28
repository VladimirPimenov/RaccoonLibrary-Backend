using RaccoonLibrary.Ordering.Domain.Contracts;
using RaccoonLibrary.Ordering.Domain.Entities;
using RaccoonLibrary.Ordering.Domain.Repositories;
using System.Runtime.CompilerServices;

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
				order = await orderRepository.CreateCustomerOrderAsync(new Order { CustomerId = customerId });
			}

			if (book != null)
				await orderRepository.AddBookToOrderAsync(book, order);
		}

		public async Task<Order> GetCurrentCustomerOrderAsync(int customerId)
		{
			Order order = await orderRepository.GetCustomerOrderAsync(customerId);

			if (order != null)
				order.OrderedBooks = await GetOrderBooks(order);

			return order;
		}

		public async Task RemoveBookFromCustomerOrderAsync(int bookId, int customerId)
		{
			Order order = await orderRepository.GetCustomerOrderAsync(customerId);

			if (order != null)
				await orderRepository.RemoveBookFromOrderAsync(bookId, order.OrderId);
		}

		private async Task<List<Book>> GetOrderBooks(Order order)
		{
			var bookIds = await orderRepository.GetOrderBookIdsAsync(order.OrderId);

			var books = new List<Book>();

			foreach(int bookId in bookIds)
			{
				Book book = await bookService.GetBookByIdAsync(bookId);

				if(book != null)
					books.Add(book);
			}

			return books;
		}
	}
}
