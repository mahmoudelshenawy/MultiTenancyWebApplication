using MediatR;
using Core.Dtos;

namespace Application.Queryies.Categories
{
    public record GetAllCategoriesQuery : IRequest<List<CategoryDto>>;
}
