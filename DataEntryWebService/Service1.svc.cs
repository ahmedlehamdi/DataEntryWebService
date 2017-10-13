using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using DataEntryDAL.Handlers;
using DataEntryDAL.DataAccessLogic;
using DataEntryWebService.ServiceIntegration;
using Newtonsoft.Json;

namespace DataEntryWebService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        //public string GetData(int value)
        //{
        //    UserModel model = new UserModel();
        //    User user = model.getUserByCredts("ahmed", "123");
        //    return string.Format("You entered: {0}", value);
        //}

        //public CompositeType GetDataUsingDataContract(CompositeType composite)
        //{
        //    if (composite == null)
        //    {
        //        throw new ArgumentNullException("composite");
        //    }
        //    if (composite.BoolValue)
        //    {
        //        composite.StringValue += "Suffix";
        //    }

        //    return composite;
        //}
        public string checkLogin(string userName, string password)
        {
            User user = null;
            try
            {
                UserHandler handler = new UserHandler();

                user = handler.doLogin(userName, password);
            }
            catch (Exception ex)
            {
                return JsonConvert.SerializeObject(new ReturnObject<string>(ErrorConstants.ERROR_EXCEPTION, ex.Message));
            }
            if (user != null)
                return JsonConvert.SerializeObject(new ReturnObject<User>(ErrorConstants.SUCCESS ,user));
            else
            {
                return JsonConvert.SerializeObject(new ReturnObject<string>(ErrorConstants.ERROR_LOGIN_FAILED, ErrorConstants.ERROR_LOGIN_FAILED_MSG));
            }
        }
    }
}
