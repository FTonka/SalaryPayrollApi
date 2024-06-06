using SalaryPayrollApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryPayrollApi.Services.Service
{
	public class EmployeeService : IEmployeeService
	{
		public decimal CalculateSalary(Employee employee)
		{
			switch (employee.WorkType)
			{
				case 1:
					return employee.Salary;
				case 2:
					return employee.WorkedDays.Value * employee.DailyWage.Value;
				case 3:
					return employee.Salary + (employee.OvertimeHours.Value * employee.OvertimeRate.Value);
				default:
					throw new ArgumentException("Geçersiz çalışan tipi");
			}
		}
	}
}
