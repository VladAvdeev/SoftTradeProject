using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLibrary.Models
{
    public class ResponseServer
    {
        public bool? IsSuccess { get; set; }
        public string Action { get; set; }
        public string Message { get; set; }
    }
}
