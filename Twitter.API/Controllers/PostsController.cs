using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Twitter.Business.Dtos.PostDtos;
using Twitter.Business.Services.Interfaces;
using Twitter.Core.Enums;

namespace Twitter.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        IPostService _service { get; }

        public PostsController(IPostService service)
        {
            _service = service;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_service.Get());
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post(PostCreateDto dto)
        {
            await _service.Create(dto);
            return Ok();
        }
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Put(int id, PostUpdateDto dto)
        {
            await _service.Update(id, dto);
            return Ok();
        }
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.Delete(id);
            return Ok();
        }
        [HttpPatch("[action]/{id}")]
        [Authorize]
        public async Task<IActionResult> React(int id, ReactionTypes type)
        {
            await _service.React(id, type);
            return Ok();
        }
    }
}
