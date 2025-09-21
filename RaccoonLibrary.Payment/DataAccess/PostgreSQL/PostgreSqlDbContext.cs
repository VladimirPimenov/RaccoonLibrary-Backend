using Microsoft.EntityFrameworkCore;
using RaccoonLibrary.Payment.Domain.Entities;
using System.Data.Common;

namespace RaccoonLibrary.Payment.DataAccess.PostgreSQL
{
	public class PostgreSqlDbContext: DbContext
	{
		public DbSet<PaymentAccount> PaymentAccount { get; set; }

		public PostgreSqlDbContext(DbContextOptions<PostgreSqlDbContext> options) 
			: base(options) { }
	}
}
