using FirstApp.Repositories.Interface;
using FirstApp.Service.Repository.ViewModel;
using MediatR;


namespace FirstApp.Core.States.Query;

public record  GetStateById(int id):IRequest<VMState>;
public class GetStateByIdHandler:IRequestHandler<GetStateById,VMState>
{
    private readonly IStateRepository _stateRepository;

    public GetStateByIdHandler(IStateRepository stateRepository)
    {
        _stateRepository = stateRepository;
    }

    public Task<VMState> Handle(GetStateById request, CancellationToken cancellationToken)
    {
        return _stateRepository.GetById(request.id);

    }
}
