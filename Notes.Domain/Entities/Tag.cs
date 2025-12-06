using Notes.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Domain.Entities
{
    public class Tag : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
