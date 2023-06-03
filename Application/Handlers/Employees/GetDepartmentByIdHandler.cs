using AutoMapper;
using MediatR;
using Application.Commands.Employees;
using Application.Queryies.Employees;
using Core.Dtos;
using Application.Interfaces;
using Core.Entities;

namespace Application.Handlers.Employees
{
    public class GetEmployeeByIdHandler : IRequestHandler<GetEmployeeByIdQuery, EmployeeDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetEmployeeByIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<EmployeeDto> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        {
           var Employee = await _unitOfWork.Employees.GetByIdAsync(request.Id);
           var EmployeeDto = _mapper.Map<Employee , EmployeeDto>(Employee);
           return EmployeeDto;
        }
    }
}