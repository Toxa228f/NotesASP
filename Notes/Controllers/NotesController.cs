using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Notes.Domain.Entities;
using Notes.Domain.Interfaces;
using Notes.Service.Implementations;
using Notes.Service.Interfaces;
using static Notes.Domain.DTOs.NoteDTOs;
using static Notes.Domain.DTOs.TagDTOs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Notes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class NotesController : ControllerBase
    {
        private INoteService service;
        private ITagService tagService;
        public NotesController(INoteService service, ITagService tagService) => (this.service,this.tagService) = (service,tagService);

        private async Task<List<string>> GetTagsName(IEnumerable<Guid>? n)
        {
            if (n == null) return null;
            List<string> tags = new();
            foreach (var item in n)
            {
                IBaseResponse<Tag> tg = await tagService.SelectByIdAsync(item);
                tags.Add(tg?.Data?.Name);
            }
            return tags;
        }

        [HttpGet("GetMyNotes")]
        public async Task<IActionResult> GetMyNotes()
        {
            string userId = User.FindFirst("userId")?.Value;
            if (userId == null) return Unauthorized();

            IBaseResponse<IEnumerable<Note>> notes = await service.GetAllByUserIdAsync(Guid.Parse(userId));

            if (notes.Data != null)
            {
                List<NoteResponseDto> result = new List<NoteResponseDto>();
                foreach (var n in notes.Data)
                {
                    List<string> tags = new();
                    foreach (var item in n?.Tags)
                    {
                        IBaseResponse<Tag> tg = await tagService.SelectByIdAsync(item);
                        tags.Add(tg?.Data?.Name);
                    }
                    result.Add(new NoteResponseDto
                    {
                        Id = n.Id,
                        Name = n.Name,
                        Description = n?.Description,
                        ImageUrls = n?.ImageUrls,
                        CreationDate = n.CreationDate,
                        Tags = await GetTagsName(n?.Tags),
                        UserId = n.UserId
                    });
                }

                return Ok(result);
            }
            else return Ok(notes.Responce);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            string userId = User.FindFirst("userId")?.Value;
            if (userId == null) return Unauthorized();

            IBaseResponse<Note> response = await service.SelectByIdAsync(id);
            if (response.Data == null || response.Data.UserId.ToString() != userId)
                return Forbid();

            if (response.Data != null)
            {
                Note note = response.Data;
                NoteResponseDto dto = new NoteResponseDto
                {
                    Id = note.Id,
                    Name = note.Name,
                    Description = note?.Description,
                    ImageUrls = note?.ImageUrls,
                    CreationDate = note.CreationDate,
                    Tags = await GetTagsName(note?.Tags),
                    UserId = note.UserId
                };

                return Ok(dto);
            }
            else return Ok(response.Responce);
        }

        // POST api/<NotesController>
        [HttpPost]
        public async Task<ActionResult<NoteResponseDto>> Create([FromBody] NoteCreateDto dto)
        {
            string userId = User.FindFirst("userId")?.Value;
            if (userId == null) return Unauthorized();

            Note note = new Note
            {
                Name = dto.Name,
                Description = dto?.Description,
                ImageUrls = dto?.ImageUrls,
                UserId = Guid.Parse(userId),
                CreationDate = DateTime.UtcNow,
                Tags = dto?.Tags
            };

            IBaseResponse<bool> response = await service.CreateAsync(note);

            NoteResponseDto result = new NoteResponseDto
            {
                Id = note.Id,
                Name = note.Name,
                Description = note?.Description,
                ImageUrls = note?.ImageUrls,
                CreationDate = note.CreationDate,
                Tags = await GetTagsName(note?.Tags),
                UserId = note.UserId
            };

            return Ok(result);
        }

        // PUT api/<NotesController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<bool>> Update(Guid id, [FromBody] NoteUpdateDto dto)
        {
            string userId = User.FindFirst("userId")?.Value;
            if (userId == null) return Unauthorized();

            IBaseResponse<Note> response = await service.SelectByIdAsync(id);
            Note existing = response.Data;
            if (existing == null || existing.UserId.ToString() != userId) return Forbid();

            existing.Name = dto.Name;
            existing.Description = dto?.Description;
            existing.ImageUrls = dto?.ImageUrls;
            existing.Tags = dto?.Tags;

            IBaseResponse<bool> updateResponse = await service.UpdateAsync(existing);
            return Ok(updateResponse.Data);
        }

        // DELETE api/<NotesController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(Guid id)
        {
            string? userId = User.FindFirst("userId")?.Value;
            if (userId is null) return Unauthorized();

            IBaseResponse<Note> response = await service.SelectByIdAsync(id);
            Note? note = response.Data;
            if (note is null || note.UserId.ToString() != userId) return Forbid();

            IBaseResponse<bool> deleteResponse = await service.DeleteAsync(note);
            return Ok(deleteResponse.Data);
        }
    }
}
