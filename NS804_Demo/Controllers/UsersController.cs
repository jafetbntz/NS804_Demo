
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using NS804_Demo.Models;
using NS804_Demo.ViewModels;

namespace NS804_Demo.Controllers
{
    public class UsersController : BaseController
    {

        public UsersController() : base() { }

        // GET: api/Users
        public List<CommonListItem<String>> GetNSUsers()
        {

            if (!_isDebugModeOn)
                return new List<CommonListItem<String>>();


            return _db.Users
                    .Select(u => new CommonListItem<String>{ Id = u.Id, Name = u.UserName })
                    .ToList();

            
        }

        // GET: api/Users/5
        [ResponseType(typeof(NSUser))]
        public IHttpActionResult Get(string id)
        {
            if (!_isDebugModeOn)
                return null;

            NSUser nSUser = _db.Users.Find(id);
            if (nSUser == null)
                return NotFound();


            return Ok(nSUser);
        }

        // PUT: api/Users/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Put(string id, GenericUserVM payload)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            NSUser currentUser = GetCurrentUser();

            if (currentUser == null)
                return BadRequest();

            if (currentUser.Id != id)
                return BadRequest();

            NSUser nSUser = _db.Users.Find(id);

            if (payload.UserName != null)
                nSUser.UserName = payload.UserName;


            if (payload.FirstName != null)
                nSUser.FirstName = payload.FirstName;

            if (payload.LastName != null)
                nSUser.LastName = payload.LastName;


            if (payload.Email != null)
                nSUser.Email = payload.Email;


            if (payload.PhoneNumber != null)
                nSUser.PhoneNumber = payload.PhoneNumber;

            if (payload.AddressLine1 != null)
                nSUser.AddressLine1 = payload.AddressLine1;


            if (payload.AddressLine2 != null)
                nSUser.AddressLine2 = payload.AddressLine2;


            if (payload.ZipCode != null)
                nSUser.ZipCode = payload.ZipCode;

            if (payload.City != null)
                nSUser.City = payload.City;


            if (payload.State != null)
                nSUser.State = payload.State;


            _db.Entry(nSUser).State = EntityState.Modified;
            bool wasSaved = false;

            try
            {
                _db.SaveChanges();
                wasSaved = true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(new CommonBooleanResponse(wasSaved));
        }



        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserExists(string id)
        {
            return _db.Users.Count(e => e.Id == id) > 0;
        }


    }
}