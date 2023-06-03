using AutoMapper;
using MediatR;
using Application.Queryies.Categories;
using Core.Dtos;
using Application.Interfaces;
using Core.Entities;

namespace Application.Handlers.Categories
{
    public class GetCategoryByIdHandler : IRequestHandler<GetCategoryByIdQuery, CategoryDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetCategoryByIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CategoryDto> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var Category = await _unitOfWork.Categories.GetByIdAsync(request.Id);
            var CategoryDto = _mapper.Map<Category, CategoryDto>(Category);
            return CategoryDto;
        }
    }
}