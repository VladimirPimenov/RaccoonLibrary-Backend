using RaccoonLibrary.Ordering.Domain.Entities;
using RaccoonLibrary.Ordering.Domain.Repositories;

namespace RaccoonLibrary.Ordering.DataAccess.PostgreSqlRepository.Implementation
{
	public class PaymentRepository : IPaymentRepository
	{
		public Task<PaymentAccount> CreatePaymentAsync(PaymentAccount paymentAccount)
		{
			throw new NotImplementedException();
		}

		public Task<int> RemovePaymentAsync(PaymentAccount paymentAccount)
		{
			throw new NotImplementedException();
		}
	}
}
