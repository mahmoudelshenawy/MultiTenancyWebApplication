using AutoMapper;
using MediatR;
using Application.Commands.Employees;
using Application.Queryies.Employees;
using Core.Dtos;
using Application.Interfaces;
using Core.Entities;

namespace Application.Handlers.Employees
{
    public class CreateEmployeeHandler : IRequestHandler<CreateEmployeeCommand , EmployeeDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateEmployeeHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<EmployeeDto> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
          var Employee = _mapper.Map<EmployeeDto,Employee>(request.Employee);
          var EmployeeAdded = await _unitOfWork.Employees.AddAsync(Employee, cancellationToken);
           var EmployeeDto = _mapper.Map<EmployeeDto>(EmployeeAdded);
           return EmployeeDto;
        }
    }
}
