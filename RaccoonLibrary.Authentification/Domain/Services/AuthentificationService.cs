using RaccoonLibrary.Authentification.Domain.Contracts;
using RaccoonLibrary.Authentification.Domain.Repositories;

using RaccoonLibrary.Authentification.Domain.DTO;
using RaccoonLibrary.Authentification.Domain.Entities;

namespace RaccoonLibrary.Authentification.Domain.Services
{
	public class AuthentificationService(
		IAuthentificationRepository authRepository,
		ITokenProvider tokenProvider)
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

		public async Task<string> LoginAsync(UserLoginRequest loginRequest)
		{
			var user = await authRepository.GetUserByName(loginRequest.Name);

			if (user == null)
				return null;

			if (user.Password != loginRequest.Password)
				return null;

			var token = tokenProvider.GenerateAccessToken(user);

			return token;
		}
	}
}
