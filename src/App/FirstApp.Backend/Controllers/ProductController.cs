using FirstApp.Core.Products.Command;
using FirstApp.Core.Products.Query;
using FirstApp.Service.Repository.ViewModel;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstApp.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;

        }
        [HttpGet]
        public async Task<ActionResult<VMProduct>> Get()
        {
            var getData = await _mediator.Send(new GetAllProduct());
            return Ok(getData);
        }
        [HttpGet("id")]
        public async Task<ActionResult<VMProduct>> Get(int id)
        {
            var getDatabyId = await _mediator.Send(new GetProductById(id));
            return Ok(getDatabyId);
        }
        [HttpPost]
        public async Task<ActionResult<VMProduct>> PostAsync([FromBody] VMProduct vMproduct)
        {
            var postData= await _mediator.Send(new CreateProduct(vMproduct));
            return Ok(postData);

        }
        [HttpPut("id")]
        public async Task <ActionResult<VMProduct>>PutAsync(int id, [FromBody] VMProduct vMProduct)
        {
            var putData = await _mediator.Send(new UpdateProduct(id, vMProduct));
            return Ok(putData);
        }
        [HttpDelete("id")]
        public async Task<ActionResult<VMProduct>>DeleteAsync(int id)
        {
            var deleteData = await _mediator.Send(new DeleteProduct(id));
            return Ok(deleteData);
        }
        
        
        }
    }

