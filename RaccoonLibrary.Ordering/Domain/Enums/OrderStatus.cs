namespace RaccoonLibrary.Ordering.Domain.Enums
{
	/// <summary>
	/// Статус заказа.
	/// </summary>
	public enum OrderStatus
	{
		/// <summary>
		/// Заказ находится в процессе оплаты.
		/// </summary>
		InProgress,

		/// <summary>
		/// Заказ успешно завершен и оплачен.
		/// </summary>
		Completed,

		/// <summary>
		/// Заказ не был оплачен.
		/// </summary>
		Failed
	}
}
