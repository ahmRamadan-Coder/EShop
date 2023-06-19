using Application.Features.SubCategoryFeatures.Commands;
using Application.Features.SubCategoryFeatures.Queries;
using Domain.Entities.Categories;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubCategoryController : BaseApiController
    {
        [HttpPost]
        public async Task<IActionResult> Create(CreateSubCategoryCommand subCategory)
        {
            return Ok(await Mediator.Send(subCategory));
        }
        [HttpGet]
        public async Task<IActionResult> GetAll() 
        {
            return Ok(await Mediator.Send(new GetAllSubCategoriesQuery()));
        }
        [HttpGet("id")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await Mediator.Send(new GetSubCategoryByIdQuery { Id = id}));
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateSubCategoryCommand subCategory)
        {
            return Ok(await Mediator.Send(subCategory));
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteSubCategoryCommand{ Id = id }));
        }
    }
}
