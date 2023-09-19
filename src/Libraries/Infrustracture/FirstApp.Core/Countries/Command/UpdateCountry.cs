

using AutoMapper;
using FirstApp.Repositories.Interface;
using FirstApp.Service.Repository.ViewModel;
using MediatR;

namespace FirstApp.Core.Countries.Command;

public  record UpdateCountry (int id,VMCountry VmCountry):IRequest<VMCountry>;

public class UpdateCountryHandler :IRequestHandler<UpdateCountry, VMCountry>
{
    private readonly ICountryRepository _countryRepository;
    private readonly IMapper _mapper;

    public UpdateCountryHandler(ICountryRepository countryRepository, IMapper mapper)
    {
        _countryRepository = countryRepository;
        _mapper = mapper;
    }

    public Task<VMCountry> Handle(UpdateCountry request, CancellationToken cancellationToken)
    {
        var updateData = _mapper.Map<Model.Country>(request.VmCountry);
        return _countryRepository.Updated(request.id, updateData);
    }
}
