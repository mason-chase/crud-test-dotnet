using CrudTest.Models.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudTest.Models.Exceptions
{
    public class ValidationException: Exception
    {
        public List<ValidationError> Errors { get; set; }
        public ValidationException(List<ValidationError> errors)
        {
            Errors = errors;
        }
    }
}
