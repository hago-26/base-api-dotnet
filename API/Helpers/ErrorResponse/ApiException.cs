

namespace API.Helpers;

public class ApiException : ApiResponse
{
    public ApiException(int statusCode, string message = null, string detalles = null) : base(statusCode, message)
    {
        Detalles = detalles;
    }

    public string Detalles { get; set; }
}
