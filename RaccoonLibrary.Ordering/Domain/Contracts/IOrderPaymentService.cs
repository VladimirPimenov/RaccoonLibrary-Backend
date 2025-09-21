using RaccoonLibrary.Ordering.Domain.DTO;
using RaccoonLibrary.Ordering.Domain.Entities;

namespace RaccoonLibrary.Ordering.Domain.Contracts
{
	public interface IOrderPaymentService
	{
		public Task<Order> RequestOrderPaymentAsync(CustomerPaymentRequest orderRequest);

		public Task<bool> CloseOrderAsync(Order order);
	}
}
