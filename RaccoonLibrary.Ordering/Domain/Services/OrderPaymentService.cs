using RaccoonLibrary.Ordering.Domain.Contracts;
using RaccoonLibrary.Ordering.Domain.DTO;
using RaccoonLibrary.Ordering.Domain.Entities;
using RaccoonLibrary.Ordering.Domain.Enums;

namespace RaccoonLibrary.Ordering.Domain.Services
{
	public class OrderPaymentService(
		IPaymentApiClient paymentClient,
		ICustomerLibraryApiClient customerLibraryСlient,
		IOrderingService orderService) 
		: IOrderPaymentService
	{
		public async Task<Order> PayOrderAsync(CustomerPaymentRequest payRequest)
		{
			var order = await orderService.GetOpenCustomerOrderAsync(payRequest.CustomerId);

			if (order == null || order.Status != OrderStatus.InProgress)
				return null;

			var paymentRequest = new PaymentServiceRequest
			{
				BankCardNumber = payRequest.BankCardNumber,
				PaymentSum = order.OrderPrice
			};

			bool payResult = await paymentClient.PayOrderAsync(paymentRequest);

			order = await CloseOrderAsync(order, payResult);

			return payResult ? order : null;
		}

		private async Task<Order> CloseOrderAsync(Order order, bool isPaidSuccessful)
		{
			if (isPaidSuccessful)
			{
				order.Status = OrderStatus.Completed;
				order.PayDate = DateTime.Now.ToUniversalTime();

				await AddOrderedBooksToCustomerAsync(order);
			}
			else
				order.Status = OrderStatus.Failed;

			order = await orderService.UpdateOrder(order);

			return order;
		}

		private async Task AddOrderedBooksToCustomerAsync(Order order)
		{
			foreach(Book book in order.OrderedBooks)
			{
				await customerLibraryСlient.AddBookToCustomerAsync(book, order.CustomerId);
			}
		}
	}
}
