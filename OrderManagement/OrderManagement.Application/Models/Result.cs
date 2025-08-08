namespace OrderManagement.Application.Models
{
    public class Result
    {
        public bool Success { get; set; }
        public string Message { get; set; }

        public static Result SuccessResult(string message) =>
            new Result { Success = true, Message = message };

        public static Result FailureResult(string message) =>
            new Result { Success = false, Message = message };
    }

    public class Result<T> : Result
    {
        public T Data { get; set; }

        public static Result<T> SuccessResult(T data, string message) =>
            new Result<T> { Success = true, Message = message, Data = data };

        public static new Result<T> FailureResult(string message) =>
            new Result<T> { Success = false, Message = message };
    }
}