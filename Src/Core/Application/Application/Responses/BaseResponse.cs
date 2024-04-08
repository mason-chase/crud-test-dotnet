using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Responses
{
    public class BaseResponse
    {
        public BaseResponse()
        {
            IsSuccess = true;
        }

        public BaseResponse(string message = null)
        {
            IsSuccess = true;
            Message = message;
        }

        public BaseResponse(string message, bool isSuccess)
        {
            IsSuccess = isSuccess;
            message = message;
        }

        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public List<string> ValidationErrors { get; set; }
    }
}