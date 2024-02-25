using System.ComponentModel.DataAnnotations;

namespace Mc2.CrudTest.Presentation.Server.DataAccess.Enum
{
    public enum ApiResultStatusCode
    {
        [Display(Name = "Success")]
        Success = 200,

        [Display(Name = "Server Error")]
        ServerError = 500,

        [Display(Name = "Bad Request Error")]
        BadRequest = 400,

        [Display(Name = "Not Found")]
        NotFound = 404,

        [Display(Name = "Request Process Error")]
        EntityProcessError = 422,

        [Display(Name = "Authentication Error")]
        UnAuthorized = 401,

        [Display(Name = "Authorization Error")]
        Forbidden = 403,

        [Display(Name = "Not Acceptable")]
        NotAcceptable = 406,

        [Display(Name = "Failed Dependency")]
        FailedDependency = 424,

        [Display(Name = "Logic Error")]
        LogicError
    }

}
