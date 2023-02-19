using System;
using IPEdge.Core.Interface;
using IPEdge.Infrastructure.Commands;
using MediatR;

namespace IPEdge.Infrastructure.CommandHandlers
{
	public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand>
	{
        private readonly IEmployeeService _employeeService;

		public DeleteEmployeeCommandHandler(IEmployeeService employeeService)
		{
            _employeeService = employeeService;
		}

        public async Task<Unit> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            _employeeService.DeleteEmployee(request.Id);

            return Unit.Value;
        }
    }
}

