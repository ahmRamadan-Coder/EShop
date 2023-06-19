using Application.Features.ProductFeatuers.Commands;
using Application.Features.ProductFeatuers.Queries;
using Application.Features.ProductFeatuers.Qureies;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ProductController : BaseApiController
    {
        [HttpPost]
        public async Task<IActionResult> Create(CreateProductCommand product)
        {
            return Ok(await Mediator.Send(product));
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllProductsQuery()));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await Mediator.Send(new GetProductByIdQuery {Id = id }));
        }
        
        [HttpPut]
        public async Task<IActionResult> Update(UpdateProductCommand product)
        {
            return Ok(await Mediator.Send(product));
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteProductByIdCommand { Id = id}));
        }
    }
}
