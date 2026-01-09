namespace RaccoonLibrary.Ordering.Domain.DTO
{
	/// <summary>
	/// Представляет запрос на оплату через платежный сервис.
	/// </summary>
	public record PaymentServiceRequest
	{
		/// <summary>
		/// Номер банковской карты для оплаты.
		/// </summary>
		public string BankCardNumber { get; init; }

		/// <summary>
		/// Сумма оплаты.
		/// </summary>
		public decimal PaymentSum { get; init; }
	}
}
