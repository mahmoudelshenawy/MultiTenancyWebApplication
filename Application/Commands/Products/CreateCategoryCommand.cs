using MediatR;
using Core.Dtos;

namespace Application.Commands.Products
{
    public record CreateProductCommand(ProductDto ProductDto) : IRequest<ProductDto>;
}
