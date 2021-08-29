using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using NS804_Demo.Models;
using NS804_Demo.Secutiry;
using NS804_Demo.ViewModels;
using System;
using System.Linq;
using System.Web.Http;

namespace NS804_Demo.Controllers
{

    /// <summary>
    /// Auth Controller class for authenticate users
    /// </summary>
    [AllowAnonymous]
    [RoutePrefix("api/auth")]
    public class AuthController : ApiController
    {
        private UserStore<NSUser> _userStore;
        private UserManager<NSUser> _manager;

        public AuthController() : base() {
            AppDBContext db = new AppDBContext();
            _userStore = new UserStore<NSUser>(db);
            _manager = new UserManager<NSUser>(_userStore);
        }


        [HttpPost]
        [Route("login")]
        public IHttpActionResult Login(LoginRequest login)
        {
            if (login == null)
                return BadRequest();

            if (!login.IsValid())
                return BadRequest();

            NSUser user  = _manager.Find(login.UserName, login.Password);
            if (user == null)
                return Ok(new AuthResponse(false, null));
            
            var token = TokenGenerator.GenerateTokenJwt(user.UserName);

            return Ok(new AuthResponse(true, token));

        }


        [HttpPost]
        [Route("register")]
        public IHttpActionResult Register(RegisterRequest payload)
        {
            if (payload == null)
                return BadRequest();

            if (!payload.IsValid())
                return BadRequest();



            var user = new NSUser() { 
                UserName = payload.UserName,
                Email = payload.UserName,
                AddressLine1 = payload.AddressLine1,
                AddressLine2= payload.AddressLine2,
                ZipCode = payload.ZipCode,
                City = payload.City,
                State = payload.State,
                FirstName = payload.FirstName,
                LastName = payload.LastName,
                PhoneNumber = payload.PhoneNumber

            };
            IdentityResult result = _manager.Create(user, payload.Password );

            if (!result.Succeeded)
                return Ok(new AuthResponse(false, null, result.Errors.ToList()));

            String token = TokenGenerator.GenerateTokenJwt(payload.UserName); ;

            return Ok(new AuthResponse(true, token));

        }
    }
}
