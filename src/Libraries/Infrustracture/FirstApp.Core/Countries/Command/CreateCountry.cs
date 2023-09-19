

using AutoMapper;
using FirstApp.Repositories.Interface;
using FirstApp.Service.Repository.ViewModel;
using MediatR;

namespace FirstApp.Core.Countries.Command;

public record CreateCountry(VMCountry VmCountry):IRequest<VMCountry>;
public class CreateCountryHander:IRequestHandler<CreateCountry,VMCountry>
{
    private readonly ICountryRepository _countryRepository;
    private readonly IMapper _mapper;

    public CreateCountryHander(ICountryRepository countryRepository, IMapper mapper)
    {
        _countryRepository = countryRepository;
        _mapper = mapper;
    }

    public Task<VMCountry> Handle(CreateCountry request, CancellationToken cancellationToken)
    {
        var createData = _mapper.Map<Model.Country>(request.VmCountry);
        return _countryRepository.Created(createData);
    }
}
