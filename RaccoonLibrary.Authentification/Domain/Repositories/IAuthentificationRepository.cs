using RaccoonLibrary.Authentification.Domain.Entities;

namespace RaccoonLibrary.Authentification.Domain.Repositories
{
	public interface IAuthentificationRepository
	{
		public Task<User> AddUserAsync(User user);

		public Task<User> GetUserByName(string name);
	}
}
