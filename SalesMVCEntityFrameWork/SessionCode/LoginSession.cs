using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SalesLibrary;

namespace SalesMVCEntityFrameWork.SessionCode
{
    [Serializable]
    public class LoginSession
    {
        public static void SetSession(Login loginSession)
        {
            HttpContext.Current.Session["loginSession"] = loginSession;
        }

        public static Login GetSession()
        {
            var session = HttpContext.Current.Session["loginSession"];
            if (session == null)
            {
                return null;
            }
            else
            {
                return session as Login;
            }
        }
    }
}