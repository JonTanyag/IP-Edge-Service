using System;
using IPEdge.Core.Interface;
using IPEdge.Infrastructure.Commands;
using IPEdge.Infrastructure.Mapper;
using MediatR;

namespace IPEdge.Infrastructure.CommandHandlers
{
	public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand>
	{
        private readonly IEmployeeService _employeeService;
        private readonly UpdateEmployeeCommandToEmployeeMapper _mapper;

		public UpdateEmployeeCommandHandler(IEmployeeService employeeService, UpdateEmployeeCommandToEmployeeMapper mapper)
		{
            _employeeService = employeeService;
            _mapper = mapper;
		}

        public async Task<Unit> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var command = _mapper.Map(request);
            _employeeService.UpdateEmployee(command);

            return Unit.Value;
        }
    }
}

