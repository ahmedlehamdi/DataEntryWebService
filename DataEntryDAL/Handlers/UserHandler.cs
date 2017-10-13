using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataEntryDAL.DataAccessLogic;

namespace DataEntryDAL.Handlers
{
    public class UserHandler
    {
        public User doLogin(string username, string password)
        {
            User validUser = null;
            using (DataClassesDataContext context = new DataClassesDataContext())
            {
                var user = (from a in context.GetTable<User>()
                        where (a.USER_NAME == username && a.USER_PASSWORD == password)
                        select a).FirstOrDefault<User>();
                if( user != null)
                {
                    validUser = user;
                }
            }
            return validUser;
        }

    }
  
}