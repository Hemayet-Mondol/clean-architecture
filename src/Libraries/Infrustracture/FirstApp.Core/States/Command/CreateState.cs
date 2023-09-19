

using AutoMapper;
using FirstApp.Repositories.Interface;
using FirstApp.Service.Repository.ViewModel;
using MediatR;

namespace FirstApp.Core.States.Command;

public  record CreateState(VMState VmState):IRequest<VMState>;
public class CreateStateHandler:IRequestHandler<CreateState,VMState>
{
    private readonly IStateRepository _stateRepository;
    private readonly IMapper _mapper;

    public CreateStateHandler(IStateRepository stateRepository, IMapper mapper)
    {
        _stateRepository = stateRepository;
        _mapper = mapper;
    }

    public Task<VMState> Handle(CreateState request, CancellationToken cancellationToken)
    {
        var createData = _mapper.Map<Model.State>(request.VmState);
        return _stateRepository.Created(createData);
            
    }
}
