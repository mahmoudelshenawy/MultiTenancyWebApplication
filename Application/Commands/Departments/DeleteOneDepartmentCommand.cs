using MediatR;
using Core.Dtos;

namespace Application.Commands.Departments
{
    public record DeleteOneDepartmentCommand(DepartmentDto DepartmentDto) : IRequest<bool>;
}
