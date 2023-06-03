using MediatR;
using Core.Dtos;

namespace Application.Commands.Employees
{
    public record DeleteOneEmployeeCommand(EmployeeDto EmployeeDto) : IRequest<bool>;
}
