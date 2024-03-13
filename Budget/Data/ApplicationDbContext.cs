using Budget.Models;
using Microsoft.EntityFrameworkCore;

namespace Budget.Data
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{

		}

		public DbSet<TransactionModel> transaction { get; set; }
		public DbSet<CategoryModel> categories { get; set; }
	}
}
