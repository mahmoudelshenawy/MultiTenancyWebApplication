using MediatR;
using Core.Dtos;

namespace Application.Commands.Categories
{
    public record CreateCategoryCommand(CategoryDto Category) : IRequest<CategoryDto>;
}
