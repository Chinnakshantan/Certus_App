using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Certus_App.PageObject
{
    class LoginPage
    {
        public string EnterUserId = "//*[@id='cphBody_txtUserName']";
        public string EnterPassword = "//*[@id='cphBody_txtPassword']";
        public string SignInBtn = "//*[@id='cphBody_ibtnSignIn']";
        public string ErrorLoginText = "//*[@id='cphBody_lblError']";


    }
}
