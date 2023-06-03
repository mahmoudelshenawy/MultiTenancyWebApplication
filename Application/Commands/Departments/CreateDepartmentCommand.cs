using MediatR;
using Core.Dtos;

namespace Application.Commands.Departments
{
    public record CreateDepartmentCommand(DepartmentDto Department) : IRequest<DepartmentDto>;
}
