

using FirstApp.Repositories.Interface;
using FirstApp.Service.Repository.ViewModel;
using MediatR;

namespace FirstApp.Core.States.Query;

public record GetAllStates:IRequest<IEnumerable<VMState>>;
public class GetallStatesHandler:IRequestHandler<GetAllStates,IEnumerable<VMState>>
{
    private readonly IStateRepository _stateRepository;

    public GetallStatesHandler(IStateRepository stateRepository)
    {
        _stateRepository = stateRepository;
    }

    public async Task<IEnumerable<VMState>> Handle(GetAllStates request, CancellationToken cancellationToken)
    {
        return await _stateRepository.GetAllAsync(x=>x.Country);
    }
}
