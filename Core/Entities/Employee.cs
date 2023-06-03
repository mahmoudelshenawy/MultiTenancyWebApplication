using Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Employee : BaseEntity, IMustHaveTenant
    {
        public string Name { get; set; }
        public decimal Salary { get; set; }
        public DateTime DateOfHiring { get; set; }

        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public string TenantId { get; set; }
    }
}
