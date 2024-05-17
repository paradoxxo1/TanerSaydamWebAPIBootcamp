using System.Net;
using System.Text.Json.Serialization;

namespace MD.Result.Patten
{
    public class ResultPattern
    {
        public bool IsSuccess { get; set; } = true;
        public List<string>? ErrorMessages { get; set; }

        [JsonIgnore]
        public int StatusCode { get; set; } = (int)HttpStatusCode.OK;

        public static ResultPattern Success()
        {
            return new ResultPattern();
        }

        public static ResultPattern Fail(int statusCode, string errorMessage)
        {
            return new ResultPattern { IsSuccess = false, StatusCode = statusCode, ErrorMessages = new List<string> { errorMessage } };
        }

        public static ResultPattern Fail(int statusCode, List<string> errorMessages)
        {
            return new ResultPattern { IsSuccess = false, StatusCode = statusCode, ErrorMessages = errorMessages };
        }

        public static ResultPattern Fail(string errorMessage)
        {
            return new ResultPattern { IsSuccess = false, StatusCode = (int)HttpStatusCode.InternalServerError, ErrorMessages = new List<string> { errorMessage } };
        }

        public static ResultPattern Fail(List<string> errorMessages)
        {
            return new ResultPattern { IsSuccess = false, StatusCode = (int)HttpStatusCode.InternalServerError, ErrorMessages = errorMessages };
        }
    }

    public class Result<T> : ResultPattern
    {
        public T? Data { get; set; }

        public static Result<T> Success(T data)
        {
            return new Result<T> { Data = data };
        }

        public static new Result<T> Fail(int statusCode, string errorMessage)
        {
            return new Result<T> { IsSuccess = false, StatusCode = statusCode, ErrorMessages = new List<string> { errorMessage } };
        }

        public static new Result<T> Fail(int statusCode, List<string> errorMessages)
        {
            return new Result<T> { IsSuccess = false, StatusCode = statusCode, ErrorMessages = errorMessages };
        }

        public static new Result<T> Fail(string errorMessage)
        {
            return new Result<T> { IsSuccess = false, StatusCode = (int)HttpStatusCode.InternalServerError, ErrorMessages = new List<string> { errorMessage } };
        }

        public static new Result<T> Fail(List<string> errorMessages)
        {
            return new Result<T> { IsSuccess = false, StatusCode = (int)HttpStatusCode.InternalServerError, ErrorMessages = errorMessages };
        }
    }
}
