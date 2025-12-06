using Notes.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Domain.Entities
{
    public class BaseResponse<T> : IBaseResponse<T>
    {
        public T Data { get; set; }
        public string Responce { get; set; }
    }
}
