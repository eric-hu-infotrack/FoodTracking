using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodTrack.Constants;
using Newtonsoft.Json;

namespace FoodTrack.Models.Responses
{
    public class ErrorResponse : ResponseBase
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("errors")]
        public List<string> ErrorMessages { get; set; } = new List<string>();

        public ErrorResponse()
        {
            Type = ErrorType.General;
        }

        public ErrorResponse(string errorMessage, string errorType = ErrorType.General, string message = null)
        {
            Type = errorType;
            Message = message ?? errorMessage;
            if (ErrorMessages == null)
            {
                ErrorMessages = new List<string>();
            }
            if (!string.IsNullOrWhiteSpace(errorMessage))
            {
                ErrorMessages.Add(errorMessage);
            }
        }
    }
}
