using SalaryPayrollApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SalaryPayrollApi.Services.Service
{
	public class EmployeeServiceTests
	{
		private readonly IEmployeeService _employeeService;
		public EmployeeServiceTests()
		{
			_employeeService = new EmployeeService();
		}
		[Fact]
		public void CalculateSalary_Type1SabitCalisan()
		{
			var employee = new Employee
			{
				WorkType = 1,
				Salary = 5000
			};

			var result = _employeeService.CalculateSalary(employee);

			Assert.Equal(5000, result);
		}
		[Fact]
		public void CalculateSalary_Type2YevmiyeciCalisan()
		{
			var employee = new Employee
			{
				WorkType = 2,
				WorkedDays = 20,
				DailyWage = 200
			};

			var result = _employeeService.CalculateSalary(employee);

			Assert.Equal(4000, result);
		}

		[Fact]
		public void CalculateSalary_Type3HakkiylaCalisan()
		{
			var employee = new Employee
			{
				WorkType = 3,
				Salary = 3000,
				OvertimeHours = 10,
				OvertimeRate = 100
			};

			var result = _employeeService.CalculateSalary(employee);

			Assert.Equal(4000, result);
		}
	}
}
