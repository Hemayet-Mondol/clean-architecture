using FirstApp.Repositories.Interface;
using FirstApp.Service.Repository.ViewModel;
using MediatR;

namespace FirstApp.Core.Cities.Query;

public  record GetCityById(int id):IRequest<VMCity>;

public class GetAllCityHandler:IRequestHandler<GetCityById,VMCity>
{
    private readonly ICityRepository _cityRepository;

    public GetAllCityHandler(ICityRepository cityRepository)
    {
        _cityRepository = cityRepository;
    }

    public Task<VMCity> Handle(GetCityById request, CancellationToken cancellationToken)
    {
        return _cityRepository.GetById(request.id);
    }
}
