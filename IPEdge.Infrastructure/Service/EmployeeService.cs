using System;
using IPEdge.Core.Domain;
using IPEdge.Core.Interface;

namespace IPEdge.Infrastructure.Service
{
	public class EmployeeService : IEmployeeService
	{
        private readonly IRepository<Employee> _repository;

		public EmployeeService(IRepository<Employee> repository)
		{
            _repository = repository;
		}

        public void AddEmployee(Employee employee)
        {
            _repository.Add(employee);
        }

        public void DeleteEmployee(int id)
        {
            _repository.Delete(id);
        }

        public async Task<List<Employee>> GetEmployees(int page, int pageSize)
        {
            return await _repository.GetAll(page, pageSize);
        }

        public void UpdateEmployee(Employee employee)
        {
            _repository.Update(employee);
        }
    }
}

