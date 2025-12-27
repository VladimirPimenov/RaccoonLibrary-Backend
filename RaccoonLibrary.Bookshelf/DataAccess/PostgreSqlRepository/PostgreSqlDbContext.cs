using Microsoft.EntityFrameworkCore;

using RaccoonLibrary.Bookshelf.Domain.Entities;

namespace RaccoonLibrary.Bookshelf.DataAccess.PostgreSqlRepository
{
	public class PostgreSqlDbContext: DbContext
	{
		public DbSet<Book> Book { get; set; }
		public DbSet<Author> Author { get; set; }
		public DbSet<Genre> Genre { get; set; }
		public DbSet<BookAuthor> BookAuthor { get; set; }
		public DbSet<BookGenre> BookGenre { get; set; }

        public PostgreSqlDbContext(DbContextOptions<PostgreSqlDbContext> options)
            : base(options) { }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Book>()
				.HasMany(b => b.Authors)
				.WithMany()
				.UsingEntity<BookAuthor>();

			modelBuilder.Entity<Book>()
				.HasMany(b => b.Genres)
				.WithMany()
				.UsingEntity<BookGenre>();
		}
	}
}
