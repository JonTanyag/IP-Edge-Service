using System;
using MediatR;

namespace IPEdge.Infrastructure.Commands
{
	public class AddEmployeeCommand : IRequest
	{
		public AddEmployeeCommand()
		{
		}
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Extension { get; set; }
        public int RoleID { get; set; }
    }
}

