using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using webdemoquanlygiay.Models;
namespace webdemoquanlygiay.DAO
{
    public class UserDao
    {
        mydbcontext db = new mydbcontext();

        public bool isExisted(string idSocial)
        {
            var user = db.Users.FirstOrDefault(u => u.idSocial == idSocial);
            if (user != null)
            {
                return true;
            }
            return false;
        }
    }
}