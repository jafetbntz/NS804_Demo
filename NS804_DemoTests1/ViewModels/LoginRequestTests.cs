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
    public class LoginRequestTests
    {
        [TestMethod()]
        public void IsValidTest_EmptyConstructor()
        {
            LoginRequest request = new LoginRequest();

            Assert.Equals(request.IsValid(), false);
        }



        [TestMethod()]
        public void IsValidTest_JustUser()
        {
            LoginRequest request = new LoginRequest();
            request.UserName = "SuperUser";

            Assert.Equals(request.IsValid(), false);
        }


        [TestMethod()]
        public void IsValidTest_JustPassword()
        {
            LoginRequest request = new LoginRequest();
            request.Password = "SuperPassword";

            Assert.Equals(request.IsValid(), false);
        }

        [TestMethod()]
        public void IsValidTest_HappyCase()
        {
            LoginRequest request = new LoginRequest();
            request.Password = "SuperPassword";
            request.UserName = "SuperUser";
            Assert.Equals(request.IsValid(), true);
        }
    }
}