using MediatR;
using Core.Dtos;

namespace Application.Queryies.Departments
{
    public record GetAllDepartmentsQuery : IRequest<List<DepartmentDto>>;
}
