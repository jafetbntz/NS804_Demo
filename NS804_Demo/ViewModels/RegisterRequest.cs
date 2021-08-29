using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NS804_Demo.ViewModels
{
    public class RegisterRequest: GenericUserVM
    {

        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        public bool IsValid()
        {
            if (String.IsNullOrEmpty(this.UserName))
                return false;

            if (String.IsNullOrEmpty(this.Password))
                return false;

            if (!this.Password.Equals(this.ConfirmPassword))
                return false;

            return true;

        }
    }
}