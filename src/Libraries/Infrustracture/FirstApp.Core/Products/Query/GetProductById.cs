using FirstApp.Repositories.Interface;
using FirstApp.Service.Repository.ViewModel;
using MediatR;

namespace FirstApp.Core.Products.Query
{
    public record GetProductById (int id): IRequest<VMProduct>;

    public class GetProductByIdHandler : IRequestHandler<GetProductById, VMProduct>
    {
        private readonly IProductRepository _productRepository;
        public GetProductByIdHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
            
        }

        public async Task<VMProduct> Handle(GetProductById request, CancellationToken cancellationToken)
        {
            return await _productRepository.GetById(request.id);
        }
    }
}
