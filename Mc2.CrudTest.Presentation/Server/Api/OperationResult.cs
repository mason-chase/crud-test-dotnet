namespace Mc2.CrudTest.Presentation.Server.Api
{
    public class OperationResult<TResult>
    {
        public TResult Result { get; private set; }

        public bool IsSuccess { get; private set; }
        public string Message { get; private set; }
        public bool IsException { get; set; }
        public bool IsNotFound { get; private set; }

        public static OperationResult<TResult> SuccessResult(string message)
        {
            return new OperationResult<TResult> { Message = message, IsSuccess = true };
        }

        public static OperationResult<TResult> SuccessResult(TResult result)
        {
            return new OperationResult<TResult> { Result = result, IsSuccess = true };
        }

        public static OperationResult<TResult> FailureResult(string message, TResult result = default)
        {
            return new OperationResult<TResult> { Result = result, Message = message, IsSuccess = false };
        }

        public static OperationResult<TResult> NotFoundResult(string message)
        {
            return new OperationResult<TResult> { Message = message, IsSuccess = false, IsNotFound = true };
        }

        public static OperationResult<TResult> ExceptionResult(string message)
        {
            return new OperationResult<TResult> { Message = message, IsSuccess = false, IsException = true };
        }
    }
}
