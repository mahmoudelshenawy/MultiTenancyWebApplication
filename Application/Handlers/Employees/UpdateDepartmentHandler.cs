using AutoMapper;
using MediatR;
using Application.Commands.Employees;
using Application.Queryies.Employees;
using Core.Dtos;
using Application.Interfaces;
using Core.Entities;

namespace Application.Handlers.Employees
{
    public class UpdateEmployeeHandler : IRequestHandler<UpdateEmployeeCommand , bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateEmployeeHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
          var Employee = _mapper.Map<EmployeeDto,Employee>(request.Employee);
          var EmployeeAdded = _unitOfWork.Employees.UpdateAsync(Employee);
          var response = await _unitOfWork.Complete(cancellationToken);
           //var EmployeeDto = _mapper.Map<EmployeeDto>(EmployeeAdded);
           return response > 0;
        }
    }
}
