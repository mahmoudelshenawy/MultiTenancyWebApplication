using AutoMapper;
using MediatR;
using Application.Commands.Employees;
using Application.Queryies.Employees;
using Core.Dtos;
using Application.Interfaces;
using Core.Entities;

namespace Application.Handlers.Employees
{
    public class DeleteOneEmployeeHandler : IRequestHandler<DeleteOneEmployeeCommand , bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteOneEmployeeHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> Handle(DeleteOneEmployeeCommand request, CancellationToken cancellationToken)
        {
            var Employee = _mapper.Map<EmployeeDto , Employee>(request.EmployeeDto);
             _unitOfWork.Employees.DeleteAsync(Employee);
             var response = await _unitOfWork.Complete(cancellationToken);
             return response > 0;
        }
    }
}
