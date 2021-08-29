using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NS804_Demo.ViewModels
{
    public class CommonBooleanResponse
    {
        public bool Success {get; set;}
        public List<String> Messages {get;set;}

        public CommonBooleanResponse() { }

        public CommonBooleanResponse(bool success) {
            this.Success = success;
        }

    }
}