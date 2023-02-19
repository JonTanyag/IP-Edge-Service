using System;
using IPEdge.Core.Domain;

namespace IPEdge.Core.Interface
{
	public interface IEmployeeService
	{
		void AddEmployee(Employee employee);
		void UpdateEmployee(Employee employee);
		void DeleteEmployee(int id);
		Task<List<Employee>> GetEmployees(int page, int pageSize);
	}
}

