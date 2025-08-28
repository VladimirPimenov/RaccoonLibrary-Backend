using Microsoft.EntityFrameworkCore;
using RaccoonLibrary.Ordering.Domain.Entities;
using RaccoonLibrary.Ordering.Domain.Repositories;

namespace RaccoonLibrary.Ordering.DataAccess.PostgreSqlRepository.Implementation
{
	public class OrderRepository(
		PostgreSqlDbContext context)
		: IOrderRepository
	{
		public async Task AddBookToOrderAsync(Book book, Order order)
		{
			OrderedBook orderedBook = new OrderedBook 
			{ 
				BookId = book.BookId, 
				OrderId = order.OrderId 
			};

			context.OrderedBook.Add(orderedBook);
			await context.SaveChangesAsync();
		}

		public async Task<Order> CreateCustomerOrderAsync(Order order)
		{
			context.Order.Add(order);
			await context.SaveChangesAsync();

			return order;
		}

		public async Task<Order> GetCustomerOrderAsync(int customerId)
		{
			return await context.Order.FirstOrDefaultAsync(order => order.CustomerId == customerId);
		}

		public async Task<List<int>> GetOrderBookIdsAsync(int orderId)
		{
			return await context.OrderedBook
							.Where(book => book.OrderId == orderId)
							.Select(book => book.BookId)
							.ToListAsync();
		}

		public async Task RemoveBookFromOrderAsync(int bookId, int orderId)
		{
			OrderedBook book = await context.OrderedBook.FirstOrDefaultAsync(book => 
															book.OrderId == orderId
															&& book.BookId == bookId);

			context.OrderedBook.Remove(book);
			await context.SaveChangesAsync();
		}

		public Task RemoveOrderAsync(int orderId)
		{
			throw new NotImplementedException();
		}
	}
}
