
using AutoMapper;
using Azure;
using FirstApp.Repositories.Interface;
using FirstApp.Service.Repository.ViewModel;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace FirstApp.Core.States.Command;

public  record UpdateState (int Id,VMState VmState):IRequest<VMState>;
public class UpdateStateHandler:IRequestHandler<UpdateState,VMState>
{
    private readonly IStateRepository _stateRepository;
    private readonly IMapper _mapper;
    public UpdateStateHandler(IStateRepository stateRepository,IMapper mapper)
    {
        _stateRepository = stateRepository;
        _mapper = mapper;
        
    }

    public async Task<VMState> Handle(UpdateState request, CancellationToken cancellationToken)
    {
        var updateData = _mapper.Map<Model.State>(request.VmState);
        return await _stateRepository.Updated(request.Id,updateData);
    }
}


public record PatchState(int Id, JsonPatchDocument<VMState> VmState, ModelStateDictionary ModelState) : IRequest<VMState>;
public class PatchStateHandler : IRequestHandler<PatchState, VMState>
{
    private readonly IStateRepository _stateRepository;
    private readonly IMapper _mapper;
    public PatchStateHandler(IStateRepository stateRepository, IMapper mapper)
    {
        _stateRepository = stateRepository;
        _mapper = mapper;

    }

    public async Task<VMState> Handle(PatchState request, CancellationToken cancellationToken)
    {
         var state = await _stateRepository.GetById(request.Id);

        request.VmState.ApplyTo(state);
        var updateData = _mapper.Map<Model.State>(state);
        return await _stateRepository.Updated(request.Id, updateData);
    }
}