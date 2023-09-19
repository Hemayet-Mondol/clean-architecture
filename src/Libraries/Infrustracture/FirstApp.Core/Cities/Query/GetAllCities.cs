

using FirstApp.Repositories.Interface;
using FirstApp.Service.Repository.ViewModel;
using MediatR;

namespace FirstApp.Core.Cities.Query
{
    public record GetAllCities:IRequest<IEnumerable<VMCity>>;
    public class GetAllCitiesHandler: IRequestHandler<GetAllCities,IEnumerable<VMCity>>
    {
        private readonly ICityRepository _cityRepository;

        public GetAllCitiesHandler(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public Task<IEnumerable<VMCity>> Handle(GetAllCities request, CancellationToken cancellationToken)
        {
            return _cityRepository.GetList();
        }
    }
}
