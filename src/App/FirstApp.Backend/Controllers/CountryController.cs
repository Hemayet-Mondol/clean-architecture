using FirstApp.Core.Countries.Command;
using FirstApp.Core.Countries.Query;
using FirstApp.Service.Repository.ViewModel;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstApp.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private IMediator _mediator;

        public CountryController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<ActionResult<VMCountry>> Get() {

            var getData = await _mediator.Send(new GetAllCountry());
            return Ok(getData);
        

        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<VMCountry>>Get(int id)
        {
            var getdataById = await _mediator.Send(new GetCountryById(id));
            return Ok(getdataById);
        }
        [HttpPost]
        public async Task<ActionResult<VMCountry>>PostAsync([FromBody]VMCountry VmCountry) 
        { 
            var postData= await _mediator.Send(new CreateCountry(VmCountry));
            return Ok(postData);
        
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult<VMCountry>> UpdateAsync(int id, [FromBody]VMCountry VmCountry)
        {
            var updateData= await _mediator.Send(new UpdateCountry(id,VmCountry));
            return Ok(updateData);
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<VMCountry>> DeleteAsync(int id)
        {
            var deleteData=await _mediator.Send(new DeleteCountry(id));
            return Ok(deleteData);
        }
    }
}
