using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using DataEntryDAL.DataAccessLogic;

namespace DataEntryWebService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        //[OperationContract]
        //string GetData(int value);

        [OperationContract]
        [WebInvoke(Method = "GET",
                   RequestFormat = WebMessageFormat.Json,
                   ResponseFormat = WebMessageFormat.Json,
                   UriTemplate = "doLogin")]
        string checkLogin(string userName, string password);

        [OperationContract]
        [WebInvoke(Method = "GET",
                   RequestFormat = WebMessageFormat.Json,
                   ResponseFormat = WebMessageFormat.Json,
                   UriTemplate = "getAllFlyers")]
        string getAllFlyers(int userID);

        [OperationContract]
        [WebInvoke(Method = "GET",
                  RequestFormat = WebMessageFormat.Json,
                  ResponseFormat = WebMessageFormat.Json,
                  UriTemplate = "getAllProviders")]
        string getAllProviders();

        [OperationContract]
        [WebInvoke(Method = "GET",
                 RequestFormat = WebMessageFormat.Json,
                 ResponseFormat = WebMessageFormat.Json,
                 UriTemplate = "getAllOfferTypes")]
        string getAllOfferTypes();

        [OperationContract]
        [WebInvoke(Method = "GET",
                 RequestFormat = WebMessageFormat.Json,
                 ResponseFormat = WebMessageFormat.Json,
                 UriTemplate = "getAllTimeFrames")]
        string getAllTimeFrames();

        [OperationContract]
        [WebInvoke(Method = "GET",
                 RequestFormat = WebMessageFormat.Json,
                 ResponseFormat = WebMessageFormat.Json,
                 UriTemplate = "getAllTimeFrames")]
        string addNewFlyerBasicData(OFFER_FLYER flyer, TIME_FRAME frame, string action);

        [OperationContract]
        [WebInvoke(Method = "GET",
                 RequestFormat = WebMessageFormat.Json,
                 ResponseFormat = WebMessageFormat.Json,
                 UriTemplate = "getAllProductCategories")]
        string getAllProductCategories();

        [OperationContract]
        [WebInvoke(Method = "GET",
                 RequestFormat = WebMessageFormat.Json,
                 ResponseFormat = WebMessageFormat.Json,
                 UriTemplate = "getAllCategoryTypes")]
        string getAllCategoryTypes(int categoryID);

        [OperationContract]
        [WebInvoke(Method = "GET",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                UriTemplate = "submitFlyerProduct")]
        string submitFlyerProduct(PRODUCT product, PRODUCT_SPEC specs);

        [OperationContract]
        [WebInvoke(Method = "GET",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                UriTemplate = "submitFlyerAllProducts")]
        string submitFlyerAllProducts(List<PRODUCT> products, List<PRODUCT_SPEC> specs);

        [OperationContract]
        [WebInvoke(Method = "GET",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                UriTemplate = "getFlyerBasicData")]
        string getFlyerBasicData(int flyerID);

        [OperationContract]
        [WebInvoke(Method = "GET",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                UriTemplate = "getFlyerProducts")]
        string getFlyerProducts(int flyerID);

        [OperationContract]
        [WebInvoke(Method = "GET",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                UriTemplate = "deleteFlyerAndProductsByID")]
        string deleteFlyerAndProductsByID(int flyerID);


        [OperationContract]
        [WebInvoke(Method = "GET",
               RequestFormat = WebMessageFormat.Json,
               ResponseFormat = WebMessageFormat.Json,
               UriTemplate = "updateUserPassword")]
        string updateUserPassword(int userID, string password);

        [OperationContract]
        [WebInvoke(Method = "GET",
              RequestFormat = WebMessageFormat.Json,
              ResponseFormat = WebMessageFormat.Json,
              UriTemplate = "approveRejectFlyer")]
        string approveRejectFlyer(int flyerID, bool approveRejectFlag);

        //[OperationContract]
        //CompositeType GetDataUsingDataContract(CompositeType composite);

        // TODO: Add your service operations here
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
