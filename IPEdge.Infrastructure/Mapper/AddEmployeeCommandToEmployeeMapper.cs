using System;
using IPEdge.Core.Domain;
using IPEdge.Infrastructure.Commands;

namespace IPEdge.Infrastructure.Mapper
{
	public class AddEmployeeCommandToEmployeeMapper
	{
		public AddEmployeeCommandToEmployeeMapper()
		{
		}

		public Employee Map(AddEmployeeCommand source)
		{
			return new Employee
			{
				Id = source.Id,
				EmployeeNumber = source.EmployeeNumber,
				FirstName = source.FirstName,
				LastName = source.LastName,
				DateJoined = source.DateJoined,
				Extension = source.Extension,
				RoleID = source.RoleID
			};
		}

	}
}

