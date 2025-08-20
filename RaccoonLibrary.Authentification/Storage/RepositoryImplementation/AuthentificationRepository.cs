using Microsoft.EntityFrameworkCore;

using RaccoonLibrary.Authentification.Domain.Repositories;

using RaccoonLibrary.Authentification.Domain.Entities;

namespace RaccoonLibrary.Authentification.Storage.RepositoryImplementation
{
	public class AuthentificationRepository(
		ApplicationDbContext context) 
		: IAuthentificationRepository
	{
		public async Task<User> AddUserAsync(User user)
		{
			await context.User.AddAsync(user);
			await context.SaveChangesAsync();

			return user;
		}

		public async Task<User> GetUserByName(string name)
		{
			return await context.User.FirstOrDefaultAsync(u => u.Name == name);
		}
	}
}
