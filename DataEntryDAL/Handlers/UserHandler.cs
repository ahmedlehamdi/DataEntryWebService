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
        public int updatePassword(int userID, string password)
        {
            try
            {
                using (DataClassesDataContext context = new DataClassesDataContext())
                {
                    var user = (from a in context.GetTable<User>()
                                where (a.USER_ID == userID)
                                select a).FirstOrDefault<User>();
                    if (user != null)
                    {
                        user.USER_PASSWORD = password;
                        context.SubmitChanges();
                    }
                }
                return userID;
            }
            catch (Exception e)
            {
                return -1;
            }
        }

        public List<User> getAllUsers()
        {
            try
            {
                using (DataClassesDataContext context = new DataClassesDataContext())
                {
                    var users = (from a in context.GetTable<User>()
                                select a).ToList<User>();
                    return users;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public int addUser(User user)
        {
            try
            {
                using (DataClassesDataContext context = new DataClassesDataContext())
                {
                    context.Users.InsertOnSubmit(user);
                    context.SubmitChanges();
                    return user.USER_ID;
                }
            }
            catch (Exception e)
            {
                return -1;
            }
        }

    }
  
}