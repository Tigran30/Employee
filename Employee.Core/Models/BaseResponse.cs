using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Core.Models
{
    public class BaseResponse<T>
    {
        public T? Result { get; set; }
        public string? ResponseMessage { get; set; }
        public int ResponseCode { get; set; }
    }
}
