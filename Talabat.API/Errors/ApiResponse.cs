using System;

namespace Talabat.API.Errors
{
    public class ApiResponse
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public ApiResponse(int statusCode , string message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageForStatusCode(statusCode);
        }

        private string GetDefaultMessageForStatusCode(int statusCode)
        => statusCode switch
        {
            400 => "A Bad Request , You Have Made",//
            401 => "Authorized , You are not",
            404 => "Resource was not found", //
            500 => "Errors are the path to the beach",
            _ =>null

        };
    }
}
