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

        public string getAllFlyers(int userID)
        {
            List<GET_ALL_FLYERS_PROCDResult> allFlyers = new List<GET_ALL_FLYERS_PROCDResult>();
            try
            {
                FlyersHandler handler = new FlyersHandler();

                allFlyers = handler.getAllFlyers(userID);
            }
            catch (Exception ex)
            {
                return JsonConvert.SerializeObject(new ReturnObject<string>(ErrorConstants.ERROR_EXCEPTION, ex.Message));
            }
            if (allFlyers != null && allFlyers.Count > 0)
                return JsonConvert.SerializeObject(new ReturnObject<List<GET_ALL_FLYERS_PROCDResult>>(ErrorConstants.SUCCESS, allFlyers));
            else
            {
                return JsonConvert.SerializeObject(new ReturnObject<string>(ErrorConstants.ERROR_NO_FLYERS_FOUND, ErrorConstants.ERROR_NO_FLYERS_FOUND_MSG));
            }
        }

        public string getAllProviders()
        {
            List<GET_ALL_PROVIDERSResult> providers = null;
            try
            {
                ProvidersHandler handler = new ProvidersHandler();

                providers = handler.getAllProviders();
            }
            catch (Exception ex)
            {
                return JsonConvert.SerializeObject(new ReturnObject<string>(ErrorConstants.ERROR_EXCEPTION, ex.Message));
            }
            if (providers != null)
                return JsonConvert.SerializeObject(new ReturnObject<List<GET_ALL_PROVIDERSResult>>(ErrorConstants.SUCCESS, providers));
            else
            {
                return JsonConvert.SerializeObject(new ReturnObject<string>(ErrorConstants.ERROR_NO_PROVIDERS_FOUND, ErrorConstants.ERROR_NO_PROVIDERS_FOUND_MSG));
            }
        }

        public string getAllOfferTypes()
        {
            List<OFFER_TYPE> types = null;
            try
            {
                FlyersHandler handler = new FlyersHandler();

                types = handler.getAllOfferTypes();
            }
            catch (Exception ex)
            {
                return JsonConvert.SerializeObject(new ReturnObject<string>(ErrorConstants.ERROR_EXCEPTION, ex.Message));
            }
            if (types != null)
                return JsonConvert.SerializeObject(new ReturnObject<List<OFFER_TYPE>>(ErrorConstants.SUCCESS, types));
            else
            {
                return JsonConvert.SerializeObject(new ReturnObject<string>(ErrorConstants.ERROR_NO_OFFER_TYPES_FOUND, ErrorConstants.ERROR_NO_OFFER_TYPES_FOUND_MSG));
            }
        }
        
        public string getAllTimeFrames()
        {
            List<TIME_FRAMES_TYPE> frames = null;
            ReturnObject <List<TIME_FRAMES_TYPE>> framesObj = null;
            try
            {
                TimeFrameHandler handler = new TimeFrameHandler();

                frames = handler.getAllTimeFrames();
                framesObj = new ReturnObject<List<TIME_FRAMES_TYPE>>(ErrorConstants.SUCCESS, frames);

                if (frames != null)
                    return JsonConvert.SerializeObject(framesObj);
                else
                {
                    return JsonConvert.SerializeObject(new ReturnObject<string>(ErrorConstants.ERROR_NO_TIME_FRAMES_FOUND, ErrorConstants.ERROR_NO_TIME_FRAMES_FOUND_MSG));
                }
            }
            catch (Exception ex)
            {
                return JsonConvert.SerializeObject(new ReturnObject<string>(ErrorConstants.ERROR_EXCEPTION, ex.Message));
            }
            
        }

        public string addNewFlyerBasicData(OFFER_FLYER flyer, TIME_FRAME frame)
        {
            
            ReturnObject<int> flyerObj = null;
            try
            {
                FlyersHandler handler = new FlyersHandler();

                var flyerID = handler.AddNewFlyer(flyer, frame);
                flyerObj = new ReturnObject<int>(ErrorConstants.SUCCESS, flyerID);

                return JsonConvert.SerializeObject(flyerObj);
            }
            catch (Exception ex)
            {
                return JsonConvert.SerializeObject(new ReturnObject<string>(ErrorConstants.ERROR_EXCEPTION, ex.Message));
            }

        }

        public string getAllProductCategories()
        {
            List<PRODUCTS_CATEGORy> cats = null;
            ReturnObject<List<PRODUCTS_CATEGORy>> catsObj = new ReturnObject<List<PRODUCTS_CATEGORy>>();
            try
            {
                ProductsHandler handler = new ProductsHandler();

                cats = handler.getAllProductCategories();
                catsObj = new ReturnObject<List<PRODUCTS_CATEGORy>>(ErrorConstants.SUCCESS, cats);

                if (cats != null)
                    return JsonConvert.SerializeObject(catsObj);
                else
                {
                    return JsonConvert.SerializeObject(new ReturnObject<string>(ErrorConstants.ERROR_NO_PRODUCT_CATEGORIES_FOUND, ErrorConstants.ERROR_NO_PRODUCT_CATEGORIES_FOUND_MSG));
                }
            }
            catch (Exception ex)
            {
                return JsonConvert.SerializeObject(new ReturnObject<string>(ErrorConstants.ERROR_EXCEPTION, ex.Message));
            }
        }

        public string getAllCategoryTypes(int categoryID)
        {
            List<PRODUCT_TYPE> types = null;
            ReturnObject<List<PRODUCT_TYPE>> typesObj = null;
            try
            {
                ProductsHandler handler = new ProductsHandler();

                types = handler.getAllCategoryTypes(categoryID);
                typesObj = new ReturnObject<List<PRODUCT_TYPE>>(ErrorConstants.SUCCESS, types);

                if (types != null)
                    return JsonConvert.SerializeObject(typesObj);
                else
                {
                    return JsonConvert.SerializeObject(new ReturnObject<string>(ErrorConstants.ERROR_NO_PRODUCT_TYPES_FOUND, ErrorConstants.ERROR_NO_PRODUCT_TYPES_FOUND_MSG));
                }
            }
            catch (Exception ex)
            {
                return JsonConvert.SerializeObject(new ReturnObject<string>(ErrorConstants.ERROR_EXCEPTION, ex.Message));
            }
        }

        public string submitFlyerProduct(PRODUCT product, PRODUCT_SPEC specs)
        {
            ReturnObject<int> output = null;
            try
            {
                ProductsHandler handler = new ProductsHandler();

                int productID = handler.AddFlyerProduct(product, specs);
                output = new ReturnObject<int>(ErrorConstants.SUCCESS, productID);

                if (productID != -1)
                    return JsonConvert.SerializeObject(output);
                else
                {
                    return JsonConvert.SerializeObject(new ReturnObject<string>(ErrorConstants.ERROR_FAILED_TO_ADD_PRODUCT, ErrorConstants.ERROR_FAILED_TO_ADD_PRODUCT_MSG));
                }
            }
            catch (Exception ex)
            {
                return JsonConvert.SerializeObject(new ReturnObject<string>(ErrorConstants.ERROR_EXCEPTION, ex.Message));
            }
        }

        public string submitFlyerAllProducts(List<PRODUCT> products, List<PRODUCT_SPEC> specs)
        {
            ReturnObject<int> output = null;
            try
            {
                ProductsHandler handler = new ProductsHandler();

                int successIndicator = handler.AddFlyerAllProducts(products, specs);
                output = new ReturnObject<int>(ErrorConstants.SUCCESS, successIndicator);

                if (successIndicator != -1)
                    return JsonConvert.SerializeObject(output);
                else
                {
                    return JsonConvert.SerializeObject(new ReturnObject<string>(ErrorConstants.ERROR_FAILED_TO_ADD_FLYER_PRODUCTS, ErrorConstants.ERROR_FAILED_TO_ADD_FLYER_PRODUCTS_MSG));
                }
            }
            catch (Exception ex)
            {
                return JsonConvert.SerializeObject(new ReturnObject<string>(ErrorConstants.ERROR_EXCEPTION, ex.Message));
            }
        }
    }
}
