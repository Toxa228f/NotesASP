using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Notes.Domain.DTOs.TagDTOs;

namespace Notes.Domain.DTOs
{
    public class NoteDTOs
    {
        public class NoteCreateDto
        {
            [Required]
            [StringLength(32, ErrorMessage = "Максимальная длина 32 символа")]
            public string Name { get; set; }

            [StringLength(128, ErrorMessage = "Максимальная длина 128 символов")]
            public string Description { get; set; }

            public List<string> ImageUrls { get; set; }
            public List<Guid> TagIds { get; set; }
        }

        public class NoteUpdateDto
        {
            [Required]
            public Guid Id { get; set; }

            [Required]
            [StringLength(32, ErrorMessage = "Максимальная длина 32 символа")]
            public string Name { get; set; }

            [StringLength(128, ErrorMessage = "Максимальная длина 128 символов")]
            public string Description { get; set; }

            public List<string> ImageUrls { get; set; }
            public List<Guid> TagIds { get; set; }
        }

        public class NoteResponseDto
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public List<string> ImageUrls { get; set; }
            public List<TagResponseDto> Tags { get; set; }
            public DateTime CreationDate { get; set; }
            public Guid UserId { get; set; }
        }
    }
}
