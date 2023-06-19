using Application.Features.BasketFeatures.Commands;
using Application.Features.BasketFeatures.Queries;
using Application.Features.CategoryFeatures.Commands;
using Application.Features.CategoryFeatures.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : BaseApiController
    {
        [HttpPost]
        public async Task<IActionResult> Create(CreateBasketCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllBasketsQuery()));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await Mediator.Send(new GetBasketByIdQuery() { Id = id }));
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteBasketCommand { Id = id }));
        }
    }
}
