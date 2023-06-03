using MediatR;
using Core.Dtos;

namespace Application.Queryies.Categories
{
    public record GetCategoryByIdQuery(int Id) : IRequest<CategoryDto>;
}