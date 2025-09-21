using RaccoonLibrary.Payment.Domain.Contracts;
using RaccoonLibrary.Payment.Domain.DTO;
using RaccoonLibrary.Payment.Domain.Entities;
using RaccoonLibrary.Payment.Domain.Enums;
using RaccoonLibrary.Payment.Domain.Repositories;

namespace RaccoonLibrary.Payment.Domain.Services
{
	public class PaymentService(
		IPaymentRepository paymentRepository,
		IBankPaymentService bankService) 
		: IPaymentService
	{
		public async Task<PaymentAccount> RequestOrderPaymentAsync(OrderPaymentRequest paymentRequest)
		{
			var bankRequest = new BankPaymentRequest
			{
				CardNumber = paymentRequest.BankCardNumber,
				PaymentSum = paymentRequest.PaymentSum
			};

			var payment = await RequestPaymentFromBank(bankRequest);

			if (payment == null)
				return null;

			return await paymentRepository.CreatePaymentAsync(payment);
		}

		public async Task<PaymentStatus> RequestPaymentStatusAsync(PaymentAccount payment)
		{
			var status = await bankService.GetPaymentStatusAsync(payment.BankPaymentId);

			switch (status)
			{
				case BankPaymentStatus.Successful:
					return PaymentStatus.PaymentSuccessful;
				case BankPaymentStatus.Failed:
					return PaymentStatus.PaymentFailed;
				default:
					return PaymentStatus.PaymentInProgress;
			}
		}

		public async Task ClosePaymentAsync(PaymentAccount payment)
		{
			payment.PaymentStatus = PaymentStatus.PaymentSuccessful;

			await paymentRepository.UpdatePaymentAsync(payment);
		}

		private async Task<PaymentAccount> RequestPaymentFromBank(BankPaymentRequest bankRequest)
		{
			int bankPaymentId = await bankService.RequestPaymentAsync(bankRequest);

			return new PaymentAccount
			{
				BankPaymentId = bankPaymentId,
				BankCardNumber = bankRequest.CardNumber,
				PaymentSum = bankRequest.PaymentSum
			};
		}
	}
}
