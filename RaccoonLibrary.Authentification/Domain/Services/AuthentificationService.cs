using RaccoonLibrary.Authentification.Domain.Contracts;

using RaccoonLibrary.Authentification.Domain.DTO;
using RaccoonLibrary.Authentification.Domain.Entities;

namespace RaccoonLibrary.Authentification.Domain.Services
{
	public class AuthentificationService : IAuthentificationService
	{
		public Task<string> LoginAsync(UserLoginRequest loginRequest)
		{
			throw new NotImplementedException();
		}

		public Task<User> RegisterAsync(UserRegisterRequest registerRequest)
		{
			throw new NotImplementedException();
		}
	}
}
