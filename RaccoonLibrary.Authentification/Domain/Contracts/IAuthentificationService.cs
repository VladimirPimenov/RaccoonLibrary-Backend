using RaccoonLibrary.Authentification.Domain.Entities;
using RaccoonLibrary.Authentification.Domain.DTO;

namespace RaccoonLibrary.Authentification.Domain.Contracts
{
	public interface IAuthentificationService
	{
		public Task<User> RegisterAsync(UserRegisterRequest registerRequest);

		public Task<string> LoginAsync(UserLoginRequest loginRequest);
	}
}
