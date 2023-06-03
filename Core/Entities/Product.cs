using Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Core.Entities
{
    public class Product : BaseEntity, IMustHaveTenant
    {
        //public Product(string name, string description, decimal price)
        //{
        //    Name = name;
        //    Description = description;
        //    Price = price;
        //}
        //protected Product()
        //{
        //}
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public string TenantId { get; set; }
    }
}
