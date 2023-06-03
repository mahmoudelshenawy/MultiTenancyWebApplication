using MediatR;
using Core.Dtos;

namespace Application.Commands.Categories
{
    public record DeleteOneCategoryCommand(CategoryDto CategoryDto) : IRequest<bool>;
}
