using Microsoft.EntityFrameworkCore;
using SalaryPayrollApi.Concrete;
using SalaryPayrollApi.Entities;

namespace SalaryPayrollApi.Repositories
{
	public class EmployeeRepository
	{

		private readonly Context _context;
        public EmployeeRepository(Context context)
        {
            _context = context;
        }
        public async Task<List<Employee>> GetAllEmployee()
		{
			
			return await _context.Employees.ToListAsync();
		}
		public async Task<Employee> AddEmployee(Employee response)
		{
			decimal totalSalary = 0;

			switch (response.WorkType)
			{
				case 1:
					totalSalary = response.Salary;
					break;
				case 2:
					if (response.WorkedDays.HasValue && response.DailyWage.HasValue)
					{
						totalSalary = response.WorkedDays.Value * response.DailyWage.Value;
					}
					break;
				case 3:
					if (response.OvertimeHours.HasValue && response.OvertimeRate.HasValue)
					{
						totalSalary = response.Salary + (response.OvertimeHours.Value * response.OvertimeRate.Value);
					}
					else
					{
						totalSalary = response.Salary; 
					}
					break;
			}
				response.Salary = totalSalary;
				var employee = await _context.Employees.AddAsync(response);
				await _context.SaveChangesAsync();
				return employee.Entity;
		}
		public async Task<Employee> GetEmployeeById(int id)
		{
			return await _context.Employees.FindAsync(id);
		}
		public async Task<bool> Exist(int employeeId)
		{
			return await _context.Employees.AnyAsync(x => x.ID == employeeId);
		}
		public async Task<Employee> UpdateEmployee(int employeeId, Employee response)
		{
			var value = await GetEmployeeById(employeeId);
			if (value != null)
			{
				value.Name = response.Name;
				value.Surname = response.Surname;
				decimal totalSalary = 0;

				switch (response.WorkType)
				{
					case 1:

						totalSalary = response.Salary;
						break;
					case 2:

						if (response.WorkedDays.HasValue && response.DailyWage.HasValue)
						{
							totalSalary = response.WorkedDays.Value * response.DailyWage.Value;
						}
						break;
					case 3:

						if (response.OvertimeHours.HasValue && response.OvertimeRate.HasValue)
						{
							totalSalary = response.Salary + (response.OvertimeHours.Value * response.OvertimeRate.Value);
						}
						else
						{
							totalSalary = response.Salary;
						}
						break;
				}
				value.Salary = totalSalary;
				value.WorkType = response.WorkType;
				value.WorkedDays = response.WorkedDays;
				value.DailyWage = response.DailyWage;
				value.OvertimeHours = response.OvertimeHours;
				value.OvertimeRate = response.OvertimeRate;
				await _context.SaveChangesAsync();
				return value;
			}
			return null;

		}

		public async Task<Employee> DeleteEmployee(int id)
		{
			var employee = await GetEmployeeById(id);
			if (employee != null)
			{
				_context.Employees.Remove(employee);
				await _context.SaveChangesAsync();
				return employee;
			}
			return null;
		}
	}
}
