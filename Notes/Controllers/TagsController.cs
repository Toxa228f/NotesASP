using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Notes.Domain.Entities;
using Notes.Domain.Interfaces;
using Notes.Service.Implementations;
using Notes.Service.Interfaces;
using static Notes.Domain.DTOs.TagDTOs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Notes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TagsController : ControllerBase
    {
        private ITagService service;

        public TagsController(ITagService service) => this.service = service;

        [HttpGet]
        public async Task<ActionResult<List<TagResponseDto>>> GetAll()
        {
            IBaseResponse<IEnumerable<Tag>> tags = await service.SelectAllAsync();

            List<TagResponseDto> result = tags.Data.Select(t => new TagResponseDto
            {
                Id = t.Id,
                Name = t.Name
            }).ToList();

            return Ok(result);
        }

        [HttpGet("id/{id}")]
        public async Task<ActionResult<TagResponseDto>> GetById(Guid id)
        {
            IBaseResponse<Tag> response = await service.SelectByIdAsync(id);
            if (response.Data == null) return NotFound();

            Tag tag = response.Data;
            TagResponseDto dto = new TagResponseDto
            {
                Id = tag.Id,
                Name = tag.Name
            };

            return Ok(dto);
        }

        [HttpGet("name/{name}")]
        public async Task<ActionResult<TagResponseDto>> GetByName(string name)
        {
            IBaseResponse<Tag> response = await service.GetTagByNameAsync(name);
            if (response.Data == null) return NotFound();

            Tag tag = response.Data;
            TagResponseDto dto = new TagResponseDto
            {
                Id = tag.Id,
                Name = tag.Name
            };

            return Ok(dto);
        }

        [HttpPost]
        public async Task<ActionResult<TagResponseDto>> Create([FromBody] TagCreateDto dto)
        {
            Tag tag = new Tag
            {
                Name = dto.Name
            };

            IBaseResponse<bool> response = await service.CreateAsync(tag);

            TagResponseDto result = new TagResponseDto
            {
                Id = tag.Id,
                Name = tag.Name
            };

            return Ok(result);
        }
    }
}
