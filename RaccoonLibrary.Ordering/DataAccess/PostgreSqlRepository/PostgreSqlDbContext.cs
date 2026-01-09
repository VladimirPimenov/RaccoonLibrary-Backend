using Microsoft.EntityFrameworkCore;

using RaccoonLibrary.Ordering.Domain.Entities;

namespace RaccoonLibrary.Ordering.DataAccess.PostgreSqlRepository
{
	public class PostgreSqlDbContext: DbContext
	{
		public DbSet<Order> Order { get; set; }
		public DbSet<OrderedBook> OrderedBook { get; set; }

		public PostgreSqlDbContext(DbContextOptions<PostgreSqlDbContext> options)
			: base(options) { }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Order>().Ignore(order => order.OrderedBooks);
		}
	}
}
