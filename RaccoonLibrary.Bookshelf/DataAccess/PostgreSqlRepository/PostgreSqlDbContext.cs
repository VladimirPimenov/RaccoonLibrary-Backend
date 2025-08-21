using Microsoft.EntityFrameworkCore;

using RaccoonLibrary.Bookshelf.Domain.Entities;

namespace RaccoonLibrary.Bookshelf.DataAccess.PostgreSqlRepository
{
	public class PostgreSqlDbContext: DbContext
	{
		public DbSet<Book> Book { get; set; }
		public DbSet<Author> Author { get; set; }

		public PostgreSqlDbContext(DbContextOptions<PostgreSqlDbContext> options)
			: base(options) { }
	}
}
