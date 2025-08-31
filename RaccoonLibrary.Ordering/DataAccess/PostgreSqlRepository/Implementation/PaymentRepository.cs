using RaccoonLibrary.Ordering.Domain.Entities;
using RaccoonLibrary.Ordering.Domain.Repositories;

namespace RaccoonLibrary.Ordering.DataAccess.PostgreSqlRepository.Implementation
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

		public async Task<int> RemovePaymentAsync(PaymentAccount paymentAccount)
		{
			context.PaymentAccount.Remove(paymentAccount);
			await context.SaveChangesAsync();

			return paymentAccount.PaymentId;
		}
	}
}
