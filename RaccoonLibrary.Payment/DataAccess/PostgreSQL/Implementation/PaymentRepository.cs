using RaccoonLibrary.Payment.Domain.Entities;

using RaccoonLibrary.Payment.Domain.Repositories;
using RaccoonLibrary.Payment.DataAccess.PostgreSQL;

namespace RaccoonLibrary.Payment.DataAccess.PostgreSqlRepository.Implementation
{
	public class PaymentRepository(
		PostgreSqlDbContext context)
		: IPaymentRepository
	{
		public async Task<PaymentAccount> CreatePaymentAsync(PaymentAccount paymentAccount)
		{
			context.PaymentAccount.Add(paymentAccount);
			await context.SaveChangesAsync();

			return paymentAccount;
		}

		public async Task<PaymentAccount> UpdatePaymentAsync(PaymentAccount paymentAccount)
		{
			context.Attach(paymentAccount);
			await context.SaveChangesAsync();

			return paymentAccount;
		}

		public async Task<int> RemovePaymentAsync(PaymentAccount paymentAccount)
		{
			context.PaymentAccount.Remove(paymentAccount);
			await context.SaveChangesAsync();

			return paymentAccount.PaymentId;
		}
	}
}
