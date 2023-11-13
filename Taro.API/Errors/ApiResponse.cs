namespace Taro.API.Errors
{
    public class ApiResponse
    {
        public int StatusCode { get; }
        public string? Message { get; }

        public ApiResponse(int statusCode, string? message = null)
        {
            StatusCode = statusCode;
            Message = message;
        }

        public string GetStatusMessage()
        {
            return StatusCode switch
            {
                200 => "OK - The request has been successfully processed.",
                400 => "Bad Request - The request is malformed or invalid.",
                404 => "Not Found - The requested resource does not exist.",
                500 => "Internal Server Error - An unexpected server error occurred.",
                _ => "Unknown Status"
            };
        }
    }
}
