namespace LogLiteThinking.Application.Common.Response;

public class ResultResponse<T>(T data, ResultType resultType, string? message = "", params string[] errors)
{
  public ResultType StatusCode { get; } = resultType;
  public IEnumerable<string> Errors { get; } = errors;
  public String Message { get; } = message;
  public T Data { get; } = data;
}