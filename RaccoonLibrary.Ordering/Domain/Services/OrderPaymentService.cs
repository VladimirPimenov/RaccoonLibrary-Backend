using RaccoonLibrary.Ordering.Domain.Contracts;
using RaccoonLibrary.Ordering.Domain.DTO;
using RaccoonLibrary.Ordering.Domain.Entities;

namespace RaccoonLibrary.Ordering.Domain.Services
{
	public class OrderPaymentService(
		IPaymentApiClient paymentClient,
		ICustomerLibraryApiClient customerLibraryclient,
		IOrderingService orderService) 
		: IOrderPaymentService
	{
		public async Task<bool> CloseOrderAsync(Order order)
		{
			await customerLibraryclient.AddOrderedBooksToCustomerAsync(order);

			await orderService.RemoveOrderAsync(order);

			return true;
		}

		public async Task<Order> RequestOrderPaymentAsync(CustomerPaymentRequest orderRequest)
		{
			var order = await orderService.GetCustomerOrderAsync(orderRequest.CustomerId);

			if (order == null)
				return null;

			var request = new PaymentServiceRequest
			{
				BankCardNumber = orderRequest.BankCardNumber,
				PaymentSum = order.OrderPrice
			};

			var responce = await paymentClient.PayOrderAsync(request);

			return responce == null ? null : order;
		}
	}
}
