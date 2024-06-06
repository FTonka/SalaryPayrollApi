using Microsoft.EntityFrameworkCore;
using SalaryPayrollApi.Entities;

namespace SalaryPayrollApi.Concrete
{
	public class Context:DbContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("server=TONKA;database=PayrollDB;integrated security=true");
		}
		public DbSet<Employee> Employees { get; set; }
		
	}
}
