namespace RaccoonLibrary.Authentification.Domain.DTO
{
	public record UserDto
	{
		public string Name { get; init; }

		public string Email { get; init; }
	}
}
