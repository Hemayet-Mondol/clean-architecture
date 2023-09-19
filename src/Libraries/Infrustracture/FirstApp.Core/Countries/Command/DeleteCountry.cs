

using AutoMapper;
using FirstApp.Repositories.Interface;
using FirstApp.Service.Repository.ViewModel;
using MediatR;

namespace FirstApp.Core.Countries.Command;

public record DeleteCountry(int id):IRequest<VMCountry>;
public class DeleteCouontryHandler:IRequestHandler<DeleteCountry,VMCountry>
{
    private readonly ICountryRepository _countryRepository;
    private readonly IMapper _mapper;

    public DeleteCouontryHandler(IMapper mapper, ICountryRepository countryRepository)
    {
        _mapper = mapper;
        _countryRepository = countryRepository;
    }

    public Task<VMCountry> Handle(DeleteCountry request, CancellationToken cancellationToken)
    {
      
        return _countryRepository.Delete(request.id);
    }
}
