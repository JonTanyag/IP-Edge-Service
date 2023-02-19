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
            var lastRecord = await _employeeService.GetEmployees(1,int.MaxValue);

            if (lastRecord != null)
            {
                command.Id = lastRecord.LastOrDefault().Id + 1;
                command.EmployeeNumber = lastRecord.LastOrDefault().EmployeeNumber + 1;
            }
            else
            {
                command.Id = 1;
                command.EmployeeNumber = 0001;
            }

            command.DateJoined = DateTime.Now;
            


            _employeeService.AddEmployee(command);

            return Unit.Value;
        }

    }
}

