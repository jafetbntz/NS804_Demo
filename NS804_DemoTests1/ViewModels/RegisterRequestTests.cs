using Microsoft.VisualStudio.TestTools.UnitTesting;
using NS804_Demo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS804_Demo.ViewModels.Tests
{
    [TestClass()]
    public class RegisterRequestTests
    {
        [TestMethod()]
        public void IsValidTest_EmptyConstructor()
        {
            RegisterRequest request = new RegisterRequest();

            Assert.Equals(request.IsValid(), false);
        }



        [TestMethod()]
        public void IsValidTest_JustUser()
        {
            RegisterRequest request = new RegisterRequest();
            request.UserName = "SuperUser";

            Assert.Equals(request.IsValid(), false);
        }


        [TestMethod()]
        public void IsValidTest_JustPassword()
        {
            RegisterRequest request = new RegisterRequest();
            request.Password = "SuperPassword";

            Assert.Equals(request.IsValid(), false);
        }

        [TestMethod()]
        public void IsValidTest_PasswordMismatch()
        {
            RegisterRequest request = new RegisterRequest();
            request.UserName = "SuperUser";
            request.Password = "SuperPassword";
            request.ConfirmPassword = "SuperPassword1";

            Assert.Equals(request.IsValid(), false);
        }


        [TestMethod()]
        public void IsValidTest_HappyCase()
        {
            RegisterRequest request = new RegisterRequest();
            request.UserName = "SuperUser";
            request.Password = "SuperPassword";
            request.ConfirmPassword = "SuperPassword";

            Assert.Equals(request.IsValid(), true);
        }
    }

}