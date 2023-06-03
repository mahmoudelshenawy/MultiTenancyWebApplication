using MediatR;
using Core.Dtos;

namespace Application.Commands.Products
{
    public record UpdateProductCommand(ProductDto ProductDto) : IRequest<bool>;
}
