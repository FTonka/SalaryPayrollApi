using SalaryPayrollApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryPayrollApi.Services.Service
{
	public interface IEmployeeService
	{
		decimal CalculateSalary(Employee employee);

	}
}
