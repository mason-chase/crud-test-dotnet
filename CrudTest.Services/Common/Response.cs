using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudTest.Services.Common
{
    public class Response<T>
    {
        public T? Data { get; set; }

        public bool Success { get; set; }
    }
}
