using MediatR;
using Core.Dtos;

namespace Application.Queryies.Employees
{
    public record GetEmployeeByIdQuery(int Id) : IRequest<EmployeeDto>;
}