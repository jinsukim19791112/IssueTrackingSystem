using app.DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace app.BL
{
    public class LoginHandler
    {
        private LoginDataAccess _loginDataAccess;

        public LoginHandler(LoginDataAccess loginDataAccess)
        {
            _loginDataAccess = loginDataAccess;
        }

        public int RequestLogin(string email, string password)
        {
            int code = 200;

            return code;
        }
    }
}