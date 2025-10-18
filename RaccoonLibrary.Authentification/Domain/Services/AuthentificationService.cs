using RaccoonLibrary.Authentification.Domain.Contracts;
using RaccoonLibrary.Authentification.Domain.Repositories;

using RaccoonLibrary.Authentification.Domain.DTO;
using RaccoonLibrary.Authentification.Domain.Entities;

namespace RaccoonLibrary.Authentification.Domain.Services
{
	public class AuthentificationService(
		IAuthentificationRepository authRepository,
		ITokenProvider tokenProvider,
		IPasswordHashService hashService)
		: IAuthentificationService
	{
		public async Task<UserDto> RegisterAsync(UserRegisterRequest registerRequest)
		{
			string hashedPassword = hashService.HashPassword(registerRequest.Password);

			var user = new User
			{
				Name = registerRequest.Name,
				Password = hashedPassword,
				Email = registerRequest.Email
			};

			var registeredUser = await authRepository.AddUserAsync(user);

			if (registeredUser == null)
				return null;

			return new UserDto
			{
				Name = registeredUser.Name,
				Email = registeredUser.Email
			};
		}

		public async Task<string> LoginAsync(UserLoginRequest loginRequest)
		{
			var user = await authRepository.GetUserByName(loginRequest.Name);

			if (user == null)
				return null;

			if (!hashService.VerifyPassword(loginRequest.Password, user.Password))
				return null;

			var token = tokenProvider.GenerateAccessToken(user);

			return token;
		}
	}
}
