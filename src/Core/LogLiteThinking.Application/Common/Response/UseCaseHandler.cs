namespace LogLiteThinking.Application.Common.Response;

public class UseCaseHandler
{
  public ResultResponse<T> NotFound<T>(string error = null)
  {
    return new ResultResponse<T>(default, ResultType.NotFound, error ?? "Not Found.");
  }

  public ResultResponse<T> Invalid<T>(string error = null)
  {
    return new ResultResponse<T>(default, ResultType.Invalid, error ?? "Invalid.");
  }

  public ResultResponse<T> Succeded<T>(T data)
  {
    return new ResultResponse<T>(data, ResultType.Ok);
  }

  public ResultResponse<T> Created<T>(T data)
  {
    return new ResultResponse<T>(data, ResultType.Created);
  }
}