using System;
using IPEdge.Core.Domain;
using IPEdge.Infrastructure.Commands;

namespace IPEdge.Infrastructure.Mapper
{
	public class UpdateEmployeeCommandToEmployeeMapper
	{
		public UpdateEmployeeCommandToEmployeeMapper()
		{
		}

		public Employee Map(UpdateEmployeeCommand source)
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

