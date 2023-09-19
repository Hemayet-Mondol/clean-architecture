

using AutoMapper;
using FirstApp.Repositories.Interface;
using FirstApp.Service.Repository.ViewModel;
using MediatR;

namespace FirstApp.Core.Cities.Command;

public  record UpdateCity(int id,VMCity VmCity):IRequest<VMCity>;
public class UpdateCityHandler:IRequestHandler<UpdateCity,VMCity>
{
    private readonly ICityRepository _cityRepository;
    private readonly IMapper _mapper;

    public UpdateCityHandler(ICityRepository cityRepository, IMapper mapper)
    {
        _cityRepository = cityRepository;
        _mapper = mapper;
    }

    public Task<VMCity> Handle(UpdateCity request, CancellationToken cancellationToken)
    {
        var updateData = _mapper.Map<Model.City>(request.VmCity);
        return _cityRepository.Updated(request.id, updateData);
    }
}
