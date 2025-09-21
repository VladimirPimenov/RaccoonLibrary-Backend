namespace RaccoonLibrary.Authentification.Domain.DTO
{
	public record UserRegisterRequest
	{
		public string Name { get; init; }

		public string Password { get; init; }

		public string Email { get; init; }
	}
}
