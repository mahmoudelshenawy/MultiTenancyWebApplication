using MediatR;
using Core.Dtos;

namespace Application.Commands.Categories
{
    public record UpdateCategoryCommand(CategoryDto Category) : IRequest<bool>;
}
