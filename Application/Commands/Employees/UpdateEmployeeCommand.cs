using MediatR;
using Core.Dtos;

namespace Application.Commands.Employees
{
    public record UpdateEmployeeCommand(EmployeeDto Employee) : IRequest<bool>;
}
