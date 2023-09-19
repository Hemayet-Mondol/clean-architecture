using FirstApp.Repositories.Interface;
using FirstApp.Service.Repository.ViewModel;
using MediatR;

namespace FirstApp.Core.Products.Command
{
    public record DeleteProduct(int id):IRequest<VMProduct>;

    public class DeleteProductHandler : IRequestHandler<DeleteProduct,VMProduct>
    {
        private readonly IProductRepository _productRepository;

        public DeleteProductHandler( IProductRepository productRepository)
        {
            _productRepository = productRepository;
            
        }

        public async Task<VMProduct> Handle(DeleteProduct request, CancellationToken cancellationToken)
        {
            return await _productRepository.Delete(request.id);
        }
    }
}
