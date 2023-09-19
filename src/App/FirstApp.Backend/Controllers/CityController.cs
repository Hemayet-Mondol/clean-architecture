using FirstApp.Core.Cities.Command;
using FirstApp.Core.Cities.Query;
using FirstApp.Service.Repository.ViewModel;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FirstApp.Backend.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CityController : ControllerBase
{
    private readonly IMediator _mediator;
    public CityController(IMediator mediator)=>_mediator = mediator;
    [HttpGet]
    public async Task<ActionResult<VMCity>> Get()=>Ok(await _mediator.Send(new GetAllCities()));
    [HttpGet("{id:int}")]
    public async Task<ActionResult<VMCity>>Get(int id)=>Ok(await _mediator.Send(new GetCityById(id)));
    [HttpPost]
    public async Task<ActionResult<VMCity>> PostAsync([FromBody] VMCity VmCity)=> Ok(await _mediator.Send(new CreateCity(VmCity)));
    [HttpPut("{id:int}")]
    public async Task<ActionResult<VMCity>>PutAsync(int id, [FromBody] VMCity VmCity)=> Ok(await _mediator.Send(new UpdateCity(id,VmCity)));
    [HttpDelete("{id:int}")]
    public async Task<ActionResult<VMCity>> DeleteAsync(int id)=>Ok(await _mediator.Send(new DeleteCity(id)));
    

}
