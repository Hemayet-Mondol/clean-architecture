

using AutoMapper;
using FirstApp.Repositories.Interface;
using FirstApp.Service.Repository.ViewModel;
using MediatR;

namespace FirstApp.Core.Cities.Command;

public record CreateCity(VMCity VmCity):IRequest<VMCity>;
public class CreateCityHandler : IRequestHandler<CreateCity,VMCity>
{
    private readonly ICityRepository _cityRepository;
    private readonly IMapper _mapper;

    public CreateCityHandler(IMapper mapper, ICityRepository cityRepository)
    {
        _mapper = mapper;
        _cityRepository = cityRepository;
    }

    public Task<VMCity> Handle(CreateCity request, CancellationToken cancellationToken)
    {
        var createData = _mapper.Map<Model.City>(request.VmCity);
        return _cityRepository.Created(createData);
    }
}
