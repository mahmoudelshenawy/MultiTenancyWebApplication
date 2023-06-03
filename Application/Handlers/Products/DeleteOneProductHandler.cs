using AutoMapper;
using MediatR;
using Application.Commands.Products;
using Application.Queryies.Products;
using Core.Dtos;
using Application.Interfaces;
using Core.Entities;


namespace Application.Handlers.Products
{
    public class DeleteOneProductHandler : IRequestHandler<DeleteOneProductCommand , bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteOneProductHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> Handle(DeleteOneProductCommand request, CancellationToken cancellationToken)
        {
            var Product = _mapper.Map<ProductDto , Product>(request.ProductDto);
             _unitOfWork.Products.DeleteAsync(Product);
             var response = await _unitOfWork.Complete(cancellationToken);
             return response > 0;
        }
    }
}
