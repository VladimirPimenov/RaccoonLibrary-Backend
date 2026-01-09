namespace RaccoonLibrary.Ordering.Domain.DTO
{
	/// <summary>
	/// Представляет запрос клиента на оплату заказа.
	/// </summary>
	public record CustomerPaymentRequest
	{
		/// <summary>
		/// Идентификатор клиента.
		/// </summary>
		public int CustomerId { get; init; }

		/// <summary>
		/// Номер банковской карты для оплаты.
		/// </summary>
		public string BankCardNumber { get; init; }
	}
}
