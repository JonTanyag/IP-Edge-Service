using System;
using IPEdge.Core.Interface;
using IPEdge.Infrastructure.Commands;
using IPEdge.Infrastructure.Mapper;
using MediatR;

namespace IPEdge.Infrastructure.CommandHandlers
{
	public class AddEmployeeCommandHandler : IRequestHandler<AddEmployeeCommand>
	{
        private readonly IEmployeeService _employeeService;
        private readonly AddEmployeeCommandToEmployeeMapper _mapper;

		public AddEmployeeCommandHandler(IEmployeeService employeeService, AddEmployeeCommandToEmployeeMapper mapper)
		{
            _employeeService = employeeService;
            _mapper = mapper;
		}

        public async Task<Unit> Handle(AddEmployeeCommand request, CancellationToken cancellationToken)
        {
            var command = _mapper.Map(request);
            _employeeService.AddEmployee(command);

            return Unit.Value;
        }

    }
}

