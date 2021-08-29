using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NS804_Demo.ViewModels
{
    public class LoginRequest
    {
  
        public string UserName { get; set; }
        public string Password { get; set; }

        public bool IsValid() {
            if (String.IsNullOrEmpty(this.UserName))
                return false;

            if (String.IsNullOrEmpty(this.Password))
                return false;

            return true;

        }
    }
}