﻿using Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Department : BaseEntity, IMustHaveTenant
    {
        public string Name { get; set; }
        public List<Employee>? Employees { get; set; } = new List<Employee>();
        public string TenantId { get; set; }
    }
}
