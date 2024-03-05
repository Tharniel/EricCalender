using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalender.Singletons
{
    public class Authorized
    {
        private static readonly Authorized userAuthStatus = new Authorized();
        private bool AuthorizedUser;
        private string Username;
        private Authorized()
        {
            AuthorizedUser = false;
            Username = null;
        }
        public static Authorized GetAuthStatus()
        {
            return userAuthStatus;
        }
        public void SetUserLoggedIn(bool isLoggedIn, string username)
        {
            AuthorizedUser = isLoggedIn;
            Username = username;
        }
        public string WhoIsUser()
        {
            return Username;
        }
        public bool IsUserLoggedIn()
        {
            return AuthorizedUser;
        }
    }
}
