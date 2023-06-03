using MediatR;
using Core.Dtos;

namespace Application.Commands.Employees
{
    public record CreateEmployeeCommand(EmployeeDto Employee) : IRequest<EmployeeDto>;
}
