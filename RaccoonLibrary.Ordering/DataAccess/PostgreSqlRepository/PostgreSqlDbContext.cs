using Microsoft.EntityFrameworkCore;

using RaccoonLibrary.Ordering.Domain.Entities;

namespace RaccoonLibrary.Ordering.DataAccess.PostgreSqlRepository
{
	public class PostgreSqlDbContext: DbContext
	{
		public DbSet<Order> Order { get; set; }
		public DbSet<OrderedBook> OrderedBook { get; set; }
		public DbSet<PaymentAccount> PaymentAccount { get; set; }

		public PostgreSqlDbContext(DbContextOptions<PostgreSqlDbContext> options)
			: base(options) { }
	}
}
