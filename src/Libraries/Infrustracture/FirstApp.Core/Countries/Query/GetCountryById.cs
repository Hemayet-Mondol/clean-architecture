

using FirstApp.Repositories.Interface;
using FirstApp.Service.Repository.ViewModel;
using MediatR;

namespace FirstApp.Core.Countries.Query;

public record GetCountryById(int id):IRequest<VMCountry>;
public class GetCountryByIdHandler : IRequestHandler<GetCountryById, VMCountry>
{
   private readonly ICountryRepository _countryRepository;

    public GetCountryByIdHandler(ICountryRepository countryRepository)
    {
        _countryRepository = countryRepository;
    }

    public async Task<VMCountry> Handle(GetCountryById request, CancellationToken cancellationToken)
    {
        return await _countryRepository.GetById(request.id);
    }
}
