using RaccoonLibrary.Authentification.Domain.Entities;

namespace RaccoonLibrary.Authentification.Domain.Contracts
{
	public interface ITokenProvider
	{
		public string GenerateAccessToken(User user);
	}
}
