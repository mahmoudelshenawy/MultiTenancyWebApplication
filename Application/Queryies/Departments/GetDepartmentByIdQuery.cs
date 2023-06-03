using MediatR;
using Core.Dtos;

namespace Application.Queryies.Departments
{
    public record GetDepartmentByIdQuery(int Id) : IRequest<DepartmentDto>;
}