using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace LearningCenter.Service.Models
{
    /// <summary>
    /// This is an Api Status Code Response Model
    /// </summary>
    public class ApiResponse
    {
        /// <summary>
        /// Status Code
        /// </summary>
        public int StatusCode { get; }

        /// <summary>
        /// Message
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get; }

        /// <summary>
        /// Api Response constructor
        /// </summary>
        /// <param name="statusCode">Status Code</param>
        /// <param name="message">Message</param>
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
