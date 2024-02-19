using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudTest.Models.Errors
{
    public class ValidationError
    {
        public string PropertyName { get; set; } = null!;

        public string ErrorMessage { get; set; } = null!;

        public ValidationError(string propertyName,string errorMessage)
        {
            PropertyName = propertyName;
            ErrorMessage = errorMessage;
        }
    }
}
