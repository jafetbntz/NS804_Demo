using Microsoft.AspNet.Identity.EntityFramework;
using NS804_Demo.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace NS804_Demo
{
    public class AppDBContext : IdentityDbContext<NSUser>
    {
        //[Important]: Remember that we are extending IdentityUserDbContext and IdentityUser,
        //including NSUser's DBSet would conflict with the already existing User DbSet.
        //public DbSet<NSUser> NSUsers { get; set; }
        public DbSet<Quote> Quotes { get; set; }
        public AppDBContext() : base("Server=(localdb)\\mssqllocaldb;Database=ns804_demo;Trusted_Connection=True;MultipleActiveResultSets=true") { }




    }
}