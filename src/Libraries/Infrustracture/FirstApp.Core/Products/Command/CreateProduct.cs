using AutoMapper;
using FirstApp.Repositories.Interface;
using FirstApp.Service.Repository.ViewModel;
using MediatR;

namespace FirstApp.Core.Products.Command
{
    public  record CreateProduct (VMProduct Vmproduct):IRequest<VMProduct>;

    public class CreateProductHandler : IRequestHandler<CreateProduct,VMProduct>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public CreateProductHandler( IProductRepository productRepository,IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            
        }

        public Task<VMProduct> Handle(CreateProduct request, CancellationToken cancellationToken)
        {
            var data =  _mapper.Map<Model.Product>(request.Vmproduct);
            return _productRepository.Created(data);
        }
    }
}
