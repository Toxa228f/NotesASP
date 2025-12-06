using Notes.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Domain.Entities
{
    public class Note : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Tag> Tags { get; set; }
        public List<string> ImageUrls { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.UtcNow;

        public Guid UserId { get; set; }
    }
}
