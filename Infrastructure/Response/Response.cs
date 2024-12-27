using System.Net;

namespace Infrastructure.Response;

public class Response<T>
{
    public int StatusCode { get; set; }
    public T Data { get; set; }
    public string Message { get; set; }

    public Response(T data)
    {
        Data = data;
        StatusCode = 200;
    }

    public Response(HttpStatusCode statusCode, string message)
    {
        Message = message;
        StatusCode = (int)statusCode;
        Data = default;
    }
}