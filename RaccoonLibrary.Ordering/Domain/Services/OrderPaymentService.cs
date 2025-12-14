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

				customerLibraryСlient.AddOrderedBooksToCustomerAsync(order);
			}
			else
				order.Status = OrderStatus.Failed;

			order = await orderService.UpdateOrder(order);

			return order;
		}
		
		//public async Task<bool> CloseOrderAsync(Order order)
		//{
		//	bool result =  await customerLibraryСlient.AddOrderedBooksToCustomerAsync(order);

		//	if(!result)
		//		return false;

		//	await orderService.RemoveOrderAsync(order);
		//	return true;
		//}

		//public async Task<Order> RequestOrderPaymentAsync(CustomerPaymentRequest orderRequest)
		//{
		//	var order = await orderService.GetCustomerOrderAsync(orderRequest.CustomerId);

		//	if (order == null)
		//		return null;

		//	var request = new PaymentServiceRequest
		//	{
		//		BankCardNumber = orderRequest.BankCardNumber,
		//		PaymentSum = order.OrderPrice
		//	};

		//	var responce = await paymentClient.PayOrderAsync(request);

		//	return responce == null ? null : order;
		//}
	}
}
