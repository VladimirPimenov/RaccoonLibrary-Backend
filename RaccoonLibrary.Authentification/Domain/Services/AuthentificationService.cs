using RaccoonLibrary.Authentification.Domain.Contracts;
using RaccoonLibrary.Authentification.Domain.Repositories;

using RaccoonLibrary.Authentification.Domain.DTO;
using RaccoonLibrary.Authentification.Domain.Entities;

namespace RaccoonLibrary.Authentification.Domain.Services
{
	public class AuthentificationService(
		IAuthentificationRepository authRepository) 
		: IAuthentificationService
	{
		public async Task<User> RegisterAsync(UserRegisterRequest registerRequest)
		{
			var user = new User
			{
				Name = registerRequest.Name,
				Password = registerRequest.Password,
				Email = registerRequest.Email
			};

			var registeredUser = await authRepository.AddUserAsync(user);

			return registeredUser;
		}

		public Task<string> LoginAsync(UserLoginRequest loginRequest)
		{
			throw new NotImplementedException();
		}
	}
}
