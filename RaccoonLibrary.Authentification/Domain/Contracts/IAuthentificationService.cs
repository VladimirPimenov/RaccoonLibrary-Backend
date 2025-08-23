using RaccoonLibrary.Authentification.Domain.DTO;

namespace RaccoonLibrary.Authentification.Domain.Contracts
{
	public interface IAuthentificationService
	{
		public Task<UserDto> RegisterAsync(UserRegisterRequest registerRequest);

		public Task<string> LoginAsync(UserLoginRequest loginRequest);
	}
}
