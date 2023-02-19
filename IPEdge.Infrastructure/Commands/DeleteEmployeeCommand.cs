using System;
using MediatR;

namespace IPEdge.Infrastructure.Commands
{
	public class DeleteEmployeeCommand : IRequest
	{
		public DeleteEmployeeCommand(int id)
		{
			Id = id;
		}

		public int Id { get; set; }
	}
}

