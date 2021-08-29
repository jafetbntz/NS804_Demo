using Microsoft.AspNet.Identity.EntityFramework;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NS804_Demo.Models
{
    public class NSUser : IdentityUser
    {
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string FirstName { get;  set; }
        public string LastName { get;  set; }

        [JsonIgnore]
        public override string PasswordHash { get; set; }
    }
}