
# Result Pattern NuGet Package

This NuGet package provides a robust and standardized way to handle the results of operations in your application. By using `Result` and `Result<T>`, you can easily manage successful and failed operations along with HTTP status codes and error messages.

## Features
- Standardized structure for representing the result of operations.
- Supports both simple results and results with data.
- Easy to integrate and use in any .NET application.
- Provides built-in methods for success and failure scenarios.
- Improves code readability and error handling consistency.

## Installation

Install the package via NuGet Package Manager:

```bash
Install-Package MD.Result.Patten
```

Or via .NET CLI:

```bash
dotnet add package MD.Result.Patten
```

## Usage

### Simple Result

#### Success Result
```csharp
var successResult = Result.Success();
// successResult.IsSuccess = true
// successResult.StatusCode = 200 (OK)
// successResult.ErrorMessages = null
```

#### Failure Result
```csharp
var failResult = Result.Fail(404, "Not Found");
// failResult.IsSuccess = false
// failResult.StatusCode = 404 (Not Found)
// failResult.ErrorMessages = ["Not Found"]
```

### Result with Data

#### Success Result
```csharp
var successDataResult = Result<string>.Success("Operation completed successfully.");
// successDataResult.IsSuccess = true
// successDataResult.StatusCode = 200 (OK)
// successDataResult.ErrorMessages = null
// successDataResult.Data = "Operation completed successfully."
```

#### Failure Result
```csharp
var failDataResult = Result<string>.Fail(400, "Bad Request");
// failDataResult.IsSuccess = false
// failDataResult.StatusCode = 400 (Bad Request)
// failDataResult.ErrorMessages = ["Bad Request"]
// failDataResult.Data = null
```

## Resource Code

```csharp
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

        public static Result Success()
        {
            return new Result();
        }

        public static Result Fail(int statusCode, string errorMessage)
        {
            return new Result { IsSuccess = false, StatusCode = statusCode, ErrorMessages = new List<string> { errorMessage } };
        }

        public static Result Fail(int statusCode, List<string> errorMessages)
        {
            return new Result { IsSuccess = false, StatusCode = statusCode, ErrorMessages = errorMessages };
        }

        public static Result Fail(string errorMessage)
        {
            return new Result { IsSuccess = false, StatusCode = (int)HttpStatusCode.InternalServerError, ErrorMessages = new List<string> { errorMessage } };
        }

        public static Result Fail(List<string> errorMessages)
        {
            return new Result { IsSuccess = false, StatusCode = (int)HttpStatusCode.InternalServerError, ErrorMessages = errorMessages };
        }
    }

    public class Result<T> : Result
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
```

[Download the package now and improve error handling in your application!](https://www.nuget.org)

Hope you like it!