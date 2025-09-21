namespace RaccoonLibrary.Authentification.Domain.DTO
{
	public record UserLoginRequest
	{
		public string Name { get; init; }

		public string Password { get; init; }
	}
}
