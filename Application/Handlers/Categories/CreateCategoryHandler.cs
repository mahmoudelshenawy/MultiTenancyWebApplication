using AutoMapper;
using MediatR;
using Application.Commands.Categories;
using Application.Queryies.Categories;
using Core.Dtos;
using Application.Interfaces;
using Core.Entities;

namespace Application.Handlers.Categories
{
    public class CreateCategoryHandler : IRequestHandler<CreateCategoryCommand , CategoryDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateCategoryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CategoryDto> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
          var Category = _mapper.Map<CategoryDto,Category>(request.Category);
          var CategoryAdded = await _unitOfWork.Categories.AddAsync(Category, cancellationToken);
           var CategoryDto = _mapper.Map<CategoryDto>(CategoryAdded);
           return CategoryDto;
        }
    }
}
