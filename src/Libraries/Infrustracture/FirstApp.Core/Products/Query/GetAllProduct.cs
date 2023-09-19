using FirstApp.Repositories.Interface;
using FirstApp.Service.Repository.ViewModel;
using MediatR;

namespace FirstApp.Core.Products.Query;

public record GetAllProduct:IRequest<IEnumerable<VMProduct>>;
public class GetAllProductHandlerQuery : IRequestHandler<GetAllProduct, IEnumerable<VMProduct>>
{
    private readonly IProductRepository _productRepository;
    public GetAllProductHandlerQuery(IProductRepository productRepository)
    {
        _productRepository = productRepository;

    }

    public async Task<IEnumerable<VMProduct>> Handle(GetAllProduct request, CancellationToken cancellationToken)
    {
        var result = await _productRepository.GetList();
        return result;
    }
}




