using AutoMapper;
using MediatR;
using Application.Commands.Departments;
using Application.Queryies.Departments;
using Core.Dtos;
using Application.Interfaces;
using Core.Entities;

namespace Application.Handlers.Departments
{
    public class GetDepartmentByIdHandler : IRequestHandler<GetDepartmentByIdQuery, DepartmentDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetDepartmentByIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<DepartmentDto> Handle(GetDepartmentByIdQuery request, CancellationToken cancellationToken)
        {
           var department = await _unitOfWork.Departments.GetByIdAsync(request.Id);
           var departmentDto = _mapper.Map<Department , DepartmentDto>(department);
           return departmentDto;
        }
    }
}