﻿using System;
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

        public string addNewFlyerBasicData(OFFER_FLYER flyer, TIME_FRAME frame, string action)
        {
            
            ReturnObject<int> flyerObj = null;
            try
            {
                FlyersHandler handler = new FlyersHandler();

                var flyerID = handler.AddNewFlyer(flyer, frame, action);
                if (flyerID != -1)
                {
                    flyerObj = new ReturnObject<int>(ErrorConstants.SUCCESS, flyerID);
                }
                else
                {
                    return JsonConvert.SerializeObject(new ReturnObject<string>(ErrorConstants.ERROR_FAILED_TO_ADD_FLYER, ErrorConstants.ERROR_FAILED_TO_ADD_FLYER_MSG));
                }

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

        public string getFlyerBasicData(int flyerID)
        {
            ReturnObject<GET_FLYER_BASIC_DATAResult> output = null;
            try
            {
                FlyersHandler handler = new FlyersHandler();

                GET_FLYER_BASIC_DATAResult flyerData = handler.GET_FLYER_DATA(flyerID);
                output = new ReturnObject<GET_FLYER_BASIC_DATAResult>(ErrorConstants.SUCCESS, flyerData);

                if (flyerData != null)
                    return JsonConvert.SerializeObject(output);
                else
                {
                    return JsonConvert.SerializeObject(new ReturnObject<string>(ErrorConstants.ERROR_FAILED_TO_GET_FLYER_DATA, ErrorConstants.ERROR_FAILED_TO_GET_FLYER_DATA_MSG));
                }
            }
            catch (Exception ex)
            {
                return JsonConvert.SerializeObject(new ReturnObject<string>(ErrorConstants.ERROR_EXCEPTION, ex.Message));
            }
        }

        public string getFlyerProducts(int flyerID)
        {
            ReturnObject<List<GET_FLYER_PRODUCTS_DATAResult>> output = null;
            try
            {
                ProductsHandler handler = new ProductsHandler();

                List<GET_FLYER_PRODUCTS_DATAResult> prodData = handler.GET_FLYER_PRODUCTS(flyerID);
                output = new ReturnObject<List<GET_FLYER_PRODUCTS_DATAResult>>(ErrorConstants.SUCCESS, prodData);

                if (prodData.Count > 0)
                    return JsonConvert.SerializeObject(output);
                else
                {
                    return JsonConvert.SerializeObject(new ReturnObject<string>(ErrorConstants.ERROR_FAILED_TO_GET_FLYER_PRODUCTS, ErrorConstants.ERROR_FAILED_TO_GET_FLYER_PRODUCTS_MSG));
                }
            }
            catch (Exception ex)
            {
                return JsonConvert.SerializeObject(new ReturnObject<string>(ErrorConstants.ERROR_EXCEPTION, ex.Message));
            }
        }

        public string deleteFlyerAndProductsByID(int flyerID)
        {
            ReturnObject<int> output = null;
            try
            {
                FlyersHandler handler = new FlyersHandler();

                int flyer = handler.deleteFlyerByID(flyerID);
                output = new ReturnObject<int>(ErrorConstants.SUCCESS, flyer);

                if (flyer >  0)
                    return JsonConvert.SerializeObject(output);
                else
                {
                    return JsonConvert.SerializeObject(new ReturnObject<string>(ErrorConstants.ERROR_FAILED_TO_DELETE_FLYER, ErrorConstants.ERROR_FAILED_TO_DELETE_FLYER_MSG));
                }
            }
            catch (Exception ex)
            {
                return JsonConvert.SerializeObject(new ReturnObject<string>(ErrorConstants.ERROR_EXCEPTION, ex.Message));
            }
        }

        public string updateUserPassword(int userID, string password)
        {
            ReturnObject<int> output = null;
            try
            {
                UserHandler handler = new UserHandler();

                int user = handler.updatePassword(userID, password);
                output = new ReturnObject<int>(ErrorConstants.SUCCESS, user);

                if (user > 0)
                    return JsonConvert.SerializeObject(output);
                else
                {
                    return JsonConvert.SerializeObject(new ReturnObject<string>(ErrorConstants.ERROR_FAILED_TO_UPDATE_PASSWORD, ErrorConstants.ERROR_FAILED_TO_UPDATE_PASSWORD_MSG));
                }
            }
            catch (Exception ex)
            {
                return JsonConvert.SerializeObject(new ReturnObject<string>(ErrorConstants.ERROR_EXCEPTION, ex.Message));
            }
        }

        public string approveRejectFlyer(int flyerID, bool approveRejectFlag)
        {
            ReturnObject<int> output = null;
            try
            {
                FlyersHandler handler = new FlyersHandler();

                int flyer = handler.approveRejectFlyer(flyerID, approveRejectFlag);
                output = new ReturnObject<int>(ErrorConstants.SUCCESS, flyer);

                if (flyer > 0)
                    return JsonConvert.SerializeObject(output);
                else
                {
                    return JsonConvert.SerializeObject(new ReturnObject<string>(ErrorConstants.ERROR_FAILED_TO_UPDATE_FLYER_STATUS, ErrorConstants.ERROR_FAILED_TO_UPDATE_FLYER_STATUS_MSG));
                }
            }
            catch (Exception ex)
            {
                return JsonConvert.SerializeObject(new ReturnObject<string>(ErrorConstants.ERROR_EXCEPTION, ex.Message));
            }
        }

        public string getListOfAllUsers()
        {
            ReturnObject<List<User>> output = null;
            try
            {
                UserHandler handler = new UserHandler();

                List<User> usersList = handler.getAllUsers();
                output = new ReturnObject<List<User>>(ErrorConstants.SUCCESS, usersList);

                if (usersList != null)
                    return JsonConvert.SerializeObject(output);
                else
                {
                    return JsonConvert.SerializeObject(new ReturnObject<string>(ErrorConstants.ERROR_FAILED_TO_GET_USERS_LIST, ErrorConstants.ERROR_FAILED_TO_GET_USERS_LIST_MSG));
                }
            }
            catch (Exception ex)
            {
                return JsonConvert.SerializeObject(new ReturnObject<string>(ErrorConstants.ERROR_EXCEPTION, ex.Message));
            }
        }

        public string addNewUser(User user)
        {
            ReturnObject<int> output = null;
            try
            {
                UserHandler handler = new UserHandler();

                int userID = handler.addUser(user);
                output = new ReturnObject<int>(ErrorConstants.SUCCESS, userID);

                if (userID > 0)
                    return JsonConvert.SerializeObject(output);
                else
                {
                    return JsonConvert.SerializeObject(new ReturnObject<string>(ErrorConstants.ERROR_FAILED_TO_ADD_USER, ErrorConstants.ERROR_FAILED_TO_ADD_USER_MSG));
                }
            }
            catch (Exception ex)
            {
                return JsonConvert.SerializeObject(new ReturnObject<string>(ErrorConstants.ERROR_EXCEPTION, ex.Message));
            }
        }
    }
}
