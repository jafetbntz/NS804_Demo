using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NS804_Demo.ViewModels
{
    public class AuthResponse
    {
        public bool Success { get; set; }
        public string JWT { get; set; }

        public List<string> Messages { get; set; }

        public AuthResponse() { }

        public AuthResponse(bool success, string token) {
            this.Success = success;
            this.JWT = token;
            this.Messages = new List<string>();

        }

        public AuthResponse(bool success, string token, List<string> errors) : this(success, token)
        {
            this.Messages = errors;
        }
    }
}