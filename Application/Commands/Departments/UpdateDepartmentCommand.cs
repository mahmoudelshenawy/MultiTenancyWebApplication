using MediatR;
using Core.Dtos;

namespace Application.Commands.Departments
{
    public record UpdateDepartmentCommand(DepartmentDto Department) : IRequest<bool>;
}
