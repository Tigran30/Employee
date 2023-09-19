using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Employee.Core.Models
{
    public class BaseResponse<T>
    {
        [JsonPropertyName("result")]
        public T? Result { get; set; }
        [JsonPropertyName("responseMessage")]
        public string? ResponseMessage { get; set; }
        [JsonPropertyName("responseCode")]
        public int ResponseCode { get; set; }
    }
}
