using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Domain.DTOs
{
    public class TagDTOs
    {
        public class TagCreateDto
        {
            [Required]
            [StringLength(32)]
            public string Name { get; set; }
        }

        public class  TagUpdateDto
        {
            [Required]
            [StringLength(32)]
            public string Name { get; set; }
        }

        public class TagResponseDto
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
        }
    }
}
