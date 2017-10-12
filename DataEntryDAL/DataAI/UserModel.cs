using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataEntryDAL.DataAccessLogic;

namespace DataEntryDAL.DataAI
{
    public class UserModel
    {

        public UserModel()
        {

        }

        public User getUserByCredts(string userName, string password)
        {
            try
            {
                using (var context = new BestOfferDataEntryDBEntities())
                {
                    var L2EQuery = context.Users.Where(s => s.USER_NAME == userName & s.USER_PASSWORD == password).FirstOrDefault<User>();
                    return L2EQuery;
                }
            }
            catch(Exception ex)
            {
                string sd = ex.StackTrace;
            }
            return null;
        }

    }
}