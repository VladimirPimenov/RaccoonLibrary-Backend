using RaccoonLibrary.Ordering.Domain.Contracts;
using RaccoonLibrary.Ordering.Domain.DTO;

namespace RaccoonLibrary.Ordering.Domain.Services
{
	public class PaymentApiClient(
		IHttpClientFactory httpClientFactory,
		IConfiguration config) 
		: IPaymentApiClient
	{
		private readonly string paymentApiAddress = config.GetValue<string>("ServiceConnections:PaymentService");

		public async Task<bool> PayOrderAsync(PaymentServiceRequest paymentRequest)
		{
			string requestString = $"{paymentApiAddress}/payment";

			HttpClient httpClient = httpClientFactory.CreateClient();
			using HttpResponseMessage responce = await httpClient.PostAsJsonAsync(requestString, paymentRequest);

			if (responce.StatusCode != System.Net.HttpStatusCode.OK)
				return false;

			return true;
		}
	}
}
