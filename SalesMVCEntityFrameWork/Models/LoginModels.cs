using SalesLibrary;
using System;
using System.Data.SqlClient;
using System.Linq;

namespace SalesMVCEntityFrameWork.Models
{
    public class LoginModels
    {
        private SalesModels salesModels = null;

        public LoginModels()
        {
            salesModels = new SalesModels();
        }

        public bool Login(string userName, string passWord)
        {
            object[] sqlparam =
            {
                new SqlParameter("@username",userName),
                new SqlParameter("@passwork",passWord)
            };
            var check = Convert.ToBoolean(salesModels.Database.SqlQuery<int>("Sp_Login @username,@passwork",sqlparam).SingleOrDefault());

            return check;
        }
    }
}