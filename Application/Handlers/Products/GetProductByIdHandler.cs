using AutoMapper;
using MediatR;
using Application.Commands.Products;
using Application.Queryies.Products;
using Core.Dtos;
using Application.Interfaces;
using Core.Entities;

namespace Application.Handlers.Products
{
    public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, ProductDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetProductByIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ProductDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
           var Product = await _unitOfWork.Products.GetByIdAsync(request.Id);
           var ProductDto = _mapper.Map<Product , ProductDto>(Product);
           return ProductDto;
        }
    }
}