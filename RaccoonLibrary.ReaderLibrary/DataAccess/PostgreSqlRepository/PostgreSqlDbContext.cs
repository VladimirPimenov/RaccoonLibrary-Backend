using Microsoft.EntityFrameworkCore;

using RaccoonLibrary.ReaderLibrary.Domain.Entities;

namespace RaccoonLibrary.ReaderLibrary.DataAccess.PostgreSqlRepository
{
	public class PostgreSqlDbContext : DbContext
	{
		public DbSet<Reader> Reader { get; set; }
		public DbSet<ReaderBook> ReaderBook { get; set; }

		public PostgreSqlDbContext(DbContextOptions<PostgreSqlDbContext> options)
			: base(options) { }
	}
}
