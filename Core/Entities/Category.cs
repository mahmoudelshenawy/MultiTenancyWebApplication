using Core.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Category : BaseEntity, IMustHaveTenant
    {
        [Required, MaxLength(250)]
        public string Name { get; set; }

        public List<Product> Products { get; set; } = new List<Product>();
        public string TenantId { get; set; }
    }
}
