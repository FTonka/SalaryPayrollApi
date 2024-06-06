using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalaryPayrollApi.Concrete;
using SalaryPayrollApi.Entities;
using SalaryPayrollApi.Repositories;

namespace SalaryPayrollApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PayrollContoller : ControllerBase
	{
		private readonly EmployeeRepository _employeeRepository;
        public PayrollContoller(EmployeeRepository employeeRepository)
        {
			_employeeRepository = employeeRepository;
        }

        [HttpGet("GetAllEmployeeAsync")]
		public async Task<IActionResult> GetAllEmployeeAsync()
		{
			var values = await _employeeRepository.GetAllEmployee();
			return Ok(values);
		}
		[HttpPost("AddEmployeeAsync")]
		public async Task<IActionResult> AddEmployeeAsync(Employee request)
		{
			var employee = await _employeeRepository.AddEmployee(request);
			return Ok(employee);
		}
		[HttpGet("GetEmployeeAsync/{id}")]
		public async Task<IActionResult> GetEmployeeAsync(int id)
		{

			var employee =await _employeeRepository.GetEmployeeById(id);
			if (employee == null)
			{
				return NotFound();
			}
			return Ok(employee);
		}

		[HttpPut("UpdateEmployeeAsync/{id}")]
		public async Task<IActionResult> UpdateEmployeeAsync(int id, Employee request)
		{
			if (await _employeeRepository.Exist(id))
			{
				var updatedEmployee = await _employeeRepository.UpdateEmployee(id, request);
				if (updatedEmployee != null)
				{
					return Ok(updatedEmployee);
				}
			}
			return NotFound();
		}
		[HttpDelete("DeleteEmployeeAsync/{id}")]
		public async Task<IActionResult> DeleteEmployeeAsync(int id)
		{
			if (await _employeeRepository.Exist(id))
			{
				var employee = await _employeeRepository.DeleteEmployee(id);
				return Ok(employee);
			}
			return NotFound();
		}
	}
}
