using AutoMapper;
using MediatR;
using Application.Commands.Departments;
using Application.Queryies.Departments;
using Core.Dtos;
using Application.Interfaces;
using Core.Entities;

namespace Application.Handlers.Departments
{
    public class GetAllDepartmentsHandler : IRequestHandler<GetAllDepartmentsQuery, List<DepartmentDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllDepartmentsHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<DepartmentDto>> Handle(GetAllDepartmentsQuery request, CancellationToken cancellationToken)
        {

            var departments = await _unitOfWork.Departments.FindListAsync(null , new []{"Employees"});
            var departmentMapping = _mapper.Map<List<Department>,List<DepartmentDto>>(departments.ToList());
            return departmentMapping;
        }
    }
}
