using MediatR;
using Core.Dtos;

namespace Application.Queryies.Employees
{
    public record GetAllEmployeesQuery : IRequest<List<EmployeeDto>>;
}
