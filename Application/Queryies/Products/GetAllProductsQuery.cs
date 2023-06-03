using MediatR;
using Core.Dtos;

namespace Application.Queryies.Products
{
    public record GetAllProductsQuery : IRequest<List<ProductDto>>;
}
