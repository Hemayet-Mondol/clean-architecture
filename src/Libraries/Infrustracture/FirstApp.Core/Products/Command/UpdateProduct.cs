using AutoMapper;
using FirstApp.Repositories.Interface;
using FirstApp.Service.Repository.ViewModel;
using MediatR;

namespace FirstApp.Core.Products.Command;

public record UpdateProduct(int id,VMProduct Vmproduct):IRequest<VMProduct>;
public class UpdateProductHandler : IRequestHandler<UpdateProduct,VMProduct>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public UpdateProductHandler(IProductRepository productRepository,IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
        
    }

    public async Task<VMProduct> Handle(UpdateProduct request, CancellationToken cancellationToken)
    {
        var result= _mapper.Map<Model.Product>(request.Vmproduct);
        return await _productRepository.Updated(request.id, result);

    }
}
