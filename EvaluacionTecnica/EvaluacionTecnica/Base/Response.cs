using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EvaluacionTecnica.Base
{
    public class Response : ResponseData<object>
    {
        public Response()
        {
            Code = "000";
            Message = string.Empty;
            MessageDetail = new object();
        }

        public string Code { get; set; }
        public string Message { get; set; }
        public object MessageDetail { get; set; }
    }
}