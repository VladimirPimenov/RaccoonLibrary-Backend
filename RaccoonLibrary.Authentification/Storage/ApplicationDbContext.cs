using Microsoft.EntityFrameworkCore;

using RaccoonLibrary.Authentification.Domain.Entities;

namespace RaccoonLibrary.Authentification.Storage
{
	public class ApplicationDbContext: DbContext
	{
		public DbSet<User> User { get; set; }

		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options) { }
	}
}
