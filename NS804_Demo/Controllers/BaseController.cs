using NS804_Demo.Models;
using System;
using System.Configuration;
using System.Linq;
using System.Web.Http;

namespace NS804_Demo.Controllers
{
    public class BaseController : ApiController
    {
        protected NSUser _currentUser = null;
        protected readonly bool _isDebugModeOn = false;
        protected readonly AppDBContext _db;
        public BaseController(): base() {

            Boolean.TryParse(ConfigurationManager.AppSettings.Get("DEBUG_MODE"), out _isDebugModeOn);
            _db = new AppDBContext();
        }

        protected NSUser GetCurrentUser()
        {
            if (_currentUser != null)
                return _currentUser;


            _currentUser = _db.Users
                            .Where(u => u.UserName == RequestContext.Principal.Identity.Name)
                            .First();

            return _currentUser;
        }
    }
}
