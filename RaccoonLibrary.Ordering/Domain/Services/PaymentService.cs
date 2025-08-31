using RaccoonLibrary.Ordering.Domain.Contracts;
using RaccoonLibrary.Ordering.Domain.DTO;
using RaccoonLibrary.Ordering.Domain.Entities;
using RaccoonLibrary.Ordering.Domain.Repositories;

namespace RaccoonLibrary.Ordering.Domain.Services
{
	public class PaymentService(
		IPaymentRepository paymentRepository,
		IOrderingService orderService,
		ICustomerLibraryService libraryService,
		IBankPaymentService bankService)
		: IPaymentService
	{
		public async Task<bool> CloseOrderPaymentAsync(PaymentAccount paymentAccount)
		{
			bool isPaymentCompleted = await bankService.IsPaymentCompleted(paymentAccount.BankPaymentId);

			if(isPaymentCompleted)
			{
				await paymentRepository.RemovePaymentAsync(paymentAccount);

				await orderService.RemoveOrderAsync(paymentAccount.Order);

				await libraryService.AddOrderedBooksToCustomerAsync(paymentAccount.Order);

				return true;
			}
			return false;
		}

		public async Task<PaymentAccount> RequestOrderPaymentAsync(CustomerPaymentRequest customerPayRequest)
		{
			var order = await orderService.GetCustomerOrderAsync(customerPayRequest.CustomerId);

			if (order == null)
				return null;

			var paymentRequest = new BankPaymentRequest
			{
				CardNumber = customerPayRequest.BankCardNumber,
				PaymentSum = order.OrderPrice
			};

			int bankPaymentId = await bankService.RequestPaymentAsync(paymentRequest);

			var payment = new PaymentAccount
			{
				OrderId = order.OrderId,
				BankPaymentId = bankPaymentId,
				BankCardNumber = customerPayRequest.BankCardNumber,
				PaymentSum = order.OrderPrice
			};

			return await paymentRepository.CreatePaymentAsync(payment);
		}
	}
}
