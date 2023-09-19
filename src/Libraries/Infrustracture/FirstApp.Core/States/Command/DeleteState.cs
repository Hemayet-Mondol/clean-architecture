
using AutoMapper;
using FirstApp.Repositories.Interface;
using FirstApp.Service.Repository.ViewModel;
using MediatR;

namespace FirstApp.Core.States.Command;

public record DeleteState(int id):IRequest<VMState>;
public class DeleteStateHandler : IRequestHandler<DeleteState, VMState>
{ 
    private readonly IStateRepository _stateRepository;
    private readonly IMapper _mapper;

    public DeleteStateHandler(IStateRepository stateRepository, IMapper mapper)
    {
        _stateRepository = stateRepository;
        _mapper = mapper;
    }

    public async Task<VMState> Handle(DeleteState request, CancellationToken cancellationToken)
    {
        
        return await _stateRepository.Delete(request.id);
    }
}
