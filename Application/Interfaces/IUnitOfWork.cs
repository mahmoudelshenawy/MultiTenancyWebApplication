using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IBaseRepository<Product> Products { get; }
        IBaseRepository<Category> Categories { get; }
        IBaseRepository<Employee> Employees { get; }
        IBaseRepository<Department> Departments { get; }
        Task<int> Complete(CancellationToken cancellationToken);
    }
}
