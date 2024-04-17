using System.ComponentModel;

namespace Mc2.CrudTest.Presentation.Application.Common.Models
{
    /// <summary>
    /// for simple use we add default generic type
    /// </summary>
    public class Result : Result<string> { }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T">The data result you want return</typeparam>
    public class Result<T>
    {
        public Result()
        {
            Status = ResultStatusEnum.Succeeded;
            Errors = new List<Error>();
        }

        public bool Succeeded => Status == ResultStatusEnum.Succeeded;

        public ResultStatusEnum Status { get; set; }

        public string StatusDescription => Status.Description();

        public string Message { get; set; }

        public List<Error> Errors { get; set; }

        public T Data { get; set; }
    }

    public enum ResultStatusEnum
    {
        [Description("Succeeded")]
        Succeeded = 200,

        [Description("Failed")]
        Failed = 500,

        [Description("Invalid Validation")]
        InvalidValidation = 501,

        [Description("Not Found")]
        NotFound = 404,

        [Description("Is Not Authorized")]
        IsNotAuthorized = 401,

        [Description("Is Not Allowed")]
        IsNotAllowed = 502,

        [Description("It's Duplicate")]
        ItsDuplicate = 503,

        [Description("Exception Throwed")]
        ExceptionThrowed = 504,

        [Description("File Is Too Large")]
        FileIsTooLarge = 505,

        [Description("File Is Too Small")]
        FileIsTooSmall = 506,

        [Description("Requires Two Factor")]
        RequiresTwoFactor = 507,

        [Description("User Is Locked")]
        IsLockedOut = 508

    }
    public static class EnumExtensions
    {
        public static string Description(this ResultStatusEnum val)
        {
            DescriptionAttribute[]? attributes = (DescriptionAttribute[])val
                .GetType()
                .GetField(val.ToString())
                ?.GetCustomAttributes(typeof(DescriptionAttribute), false)!;
            return attributes.Length > 0 ? attributes[0].Description : string.Empty;

        }
    }
    public class Error
    {
        public Error()
        {

        }
        public Error(string property, string description)
        {
            Property = property;
            Description = description;
        }
        /// <summary>
        /// Gets or sets the code for this error.
        /// </summary>
        /// <value>
        /// The code for this error.
        /// </value>
        public string Property { get; set; }

        /// <summary>
        /// Gets or sets the description for this error.
        /// </summary>
        /// <value>
        /// The description for this error.
        /// </value>
        public string Description { get; set; }
    }
}
