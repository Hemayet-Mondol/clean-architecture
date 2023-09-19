

using AutoMapper;
using FirstApp.Repositories.Interface;
using FirstApp.Service.Repository.ViewModel;
using MediatR;

namespace FirstApp.Core.Cities.Command;

public record DeleteCity(int id):IRequest<VMCity>;
public class DeleteCityHandler:IRequestHandler<DeleteCity,VMCity>
{
    private readonly ICityRepository _cityRepository;
    

    public DeleteCityHandler( ICityRepository cityRepository)
    {
        
        _cityRepository = cityRepository;
    }

    public Task<VMCity> Handle(DeleteCity request, CancellationToken cancellationToken)
    {
        return _cityRepository.Delete(request.id);
    }
}
