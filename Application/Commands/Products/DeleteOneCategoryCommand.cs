using MediatR;
using Core.Dtos;

namespace Application.Commands.Products
{
    public record DeleteOneProductCommand(ProductDto ProductDto) : IRequest<bool>;
}
