using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace LearningCenter.Service.Models
{
    public class ApiResponse
    {
        public int StatusCode { get; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get; }

        public ApiResponse(int statusCode, string message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageForStatusCode(statusCode);
        }

        private static string GetDefaultMessageForStatusCode(int statusCode)
        {
            switch (statusCode)
            {
                case 400:
                    return "Bad Request";
                case 401:
                    return "Unathorized";
                case 403:
                    return "Forbidden";
                case 404:
                    return "User not found";
                case 500:
                    return "An unhandled error occurred";
                case 501:
                    return "Not Implemented";
                default:
                    return null;
            }
        }
    }
}
