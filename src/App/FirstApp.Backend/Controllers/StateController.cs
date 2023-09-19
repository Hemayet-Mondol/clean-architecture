using Azure;
using FirstApp.Core.Countries.Command;
using FirstApp.Core.Countries.Query;
using FirstApp.Core.States.Command;
using FirstApp.Core.States.Query;
using FirstApp.Service.Repository.ViewModel;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace FirstApp.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateController : ControllerBase
    {
        private IMediator _mediator;

        public StateController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<ActionResult<VMState>> Get()
        {

            var getData = await _mediator.Send(new GetAllStates());
            return Ok(getData);


        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<VMState>> Get(int id)
        {
            var getdataById = await _mediator.Send(new GetStateById(id));
            return Ok(getdataById);
        }
        [HttpPost]
        public async Task<ActionResult<VMState>> PostAsync([FromBody] VMState VmState)
        {
            var postData = await _mediator.Send(new CreateState(VmState));
            return Ok(postData);

        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult<VMState>> UpdateAsync(int id, [FromBody] VMState VmState)
        {
            var updateData = await _mediator.Send(new UpdateState(id, VmState));
            return Ok(updateData);
        }
        [HttpPatch("{id:int}")]
        public async Task<ActionResult<VMState>> PathAsync(int id, [FromBody] JsonPatchDocument<VMState> VmState)
        {
            var updateData = await _mediator.Send(new PatchState(id, VmState,ModelState));
            return Ok(updateData);
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<VMState>> DeleteAsync(int id)
        {
            var deleteData = await _mediator.Send(new DeleteState(id));
            return Ok(deleteData);
        }
    }
}
