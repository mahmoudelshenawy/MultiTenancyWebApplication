using System.ComponentModel.DataAnnotations;

namespace Core.Dtos
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? TenantId { get; set; }
        public List<ProductDto> Products { get; set; } = new List<ProductDto>();
    }
}
