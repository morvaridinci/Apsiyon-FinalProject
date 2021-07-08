using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Application.Concrete.Dtos
{
    public class ApiResult
    {
        //status seklinde istedigi icin bu attribute u kullandik
        [JsonPropertyName("status")]
        public bool Status { get; set; }
        [JsonPropertyName("token")]
        public string Token { get; set; }
    }
}
