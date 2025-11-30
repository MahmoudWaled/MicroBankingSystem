using System;
using System.Collections.Generic;
using System.Text;

namespace MicroBankingSystem.domain.ResponseHelper
{
    public class ApiResponse<T>(int statusCode, string? messgae = null, T? data = default)
    {
        public int StatusCode { get; set; } = statusCode;
        public string Message { get; set; } = messgae ?? GetMessageFromStatusCode(statusCode);
        public T? Data { get; set; } = data;
        public bool Success { get; set; } = statusCode >= 200 && statusCode < 300;


        public static string GetMessageFromStatusCode(int statusCode)
        {
            return statusCode switch
            {
                200 => "Success",
                201 => "Created",
                204 => "No Content",
                400 => "Bad Request",
                401 => "Unauthorized",
                403 => "Forbidden",
                404 => "Not Found",
                500 => "Internal Server Error",
                _ => "Unknown Status"

            };

        }
    }
}
