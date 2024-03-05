using Microsoft.EntityFrameworkCore;
using SmartPay.Server.Models;
namespace SmartPay.Server.Data
{
	public class DataContext : DbContext {
		public DbSet<Employee> Employees { get; set; }
		public DbSet<PayslipDetails> PayslipsDetails { get; set; }

		public DataContext(DbContextOptions<DataContext> options) : base(options) { }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
		}
	}
}
