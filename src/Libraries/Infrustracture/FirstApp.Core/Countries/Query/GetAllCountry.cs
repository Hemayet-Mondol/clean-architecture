

using FirstApp.Repositories.Interface;
using FirstApp.Service.Repository.ViewModel;
using MediatR;

namespace FirstApp.Core.Countries.Query;

public record GetAllCountry:IRequest<IEnumerable<VMCountry>>;
public class  GetAllCountryHandler:IRequestHandler<GetAllCountry, IEnumerable<VMCountry>>
{
    private readonly ICountryRepository _countryRepository;

    public GetAllCountryHandler(ICountryRepository countryRepository)
    {
        _countryRepository = countryRepository;
    }

    public async Task<IEnumerable<VMCountry>> Handle(GetAllCountry request, CancellationToken cancellationToken)
    {
        var result = await _countryRepository.GetList();
        return result;
    }
}

