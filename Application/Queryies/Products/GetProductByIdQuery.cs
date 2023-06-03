using MediatR;
using Core.Dtos;

namespace Application.Queryies.Products
{
    public record GetProductByIdQuery(int Id) : IRequest<ProductDto>;
}