using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataEntryWebService.ServiceIntegration
{
    public class ErrorConstants
    {
        public readonly static int ERROR_EXCEPTION = 9999;
        public readonly static int SUCCESS = 0;

        public readonly static int ERROR_LOGIN_FAILED = 1111;
        public readonly static string ERROR_LOGIN_FAILED_MSG = "Failed to Login";

        public readonly static int ERROR_NO_FLYERS_FOUND = 2222;
        public readonly static string ERROR_NO_FLYERS_FOUND_MSG = "No Flyers Found";

        public readonly static int ERROR_NO_PROVIDERS_FOUND = 3333;
        public readonly static string ERROR_NO_PROVIDERS_FOUND_MSG = "No Providers Found";

        public readonly static int ERROR_NO_OFFER_TYPES_FOUND = 4444;
        public readonly static string ERROR_NO_OFFER_TYPES_FOUND_MSG = "No Offer Types Found";

        public readonly static int ERROR_NO_TIME_FRAMES_FOUND = 5555;
        public readonly static string ERROR_NO_TIME_FRAMES_FOUND_MSG = "No Time Frames Found";

        public readonly static int ERROR_NO_PRODUCT_CATEGORIES_FOUND = 6666;
        public readonly static string ERROR_NO_PRODUCT_CATEGORIES_FOUND_MSG = "No Product Categories Found";

        public readonly static int ERROR_NO_PRODUCT_TYPES_FOUND = 7777;
        public readonly static string ERROR_NO_PRODUCT_TYPES_FOUND_MSG = "No Categories Types Found";

        public readonly static int ERROR_FAILED_TO_ADD_PRODUCT = 8888;
        public readonly static string ERROR_FAILED_TO_ADD_PRODUCT_MSG = "Failed to Add Product";

        public readonly static int ERROR_FAILED_TO_ADD_FLYER_PRODUCTS = 9999;
        public readonly static string ERROR_FAILED_TO_ADD_FLYER_PRODUCTS_MSG = "Failed to Add Flyer Products";

        public readonly static int ERROR_FAILED_TO_GET_FLYER_DATA = 121212;
        public readonly static string ERROR_FAILED_TO_GET_FLYER_DATA_MSG = "Failed to retrieve Flyer Basic Data";

        public readonly static int ERROR_FAILED_TO_GET_FLYER_PRODUCTS = 131313;
        public readonly static string ERROR_FAILED_TO_GET_FLYER_PRODUCTS_MSG = "No Products Found";

        public readonly static int ERROR_FAILED_TO_ADD_FLYER = 141414;
        public readonly static string ERROR_FAILED_TO_ADD_FLYER_MSG = "Failed to Add Flyer";

        public readonly static int ERROR_FAILED_TO_UPDATE_FLYER = 151515;
        public readonly static string ERROR_FAILED_TO_UPDATE_FLYER_MSG = "Failed to Add Flyer";

        public readonly static int ERROR_FAILED_TO_DELETE_FLYER = 161616;
        public readonly static string ERROR_FAILED_TO_DELETE_FLYER_MSG = "Failed to Delete Flyer";

        public readonly static int ERROR_FAILED_TO_UPDATE_PASSWORD = 171717;
        public readonly static string ERROR_FAILED_TO_UPDATE_PASSWORD_MSG = "Failed to Update User Password";

        public readonly static int ERROR_FAILED_TO_UPDATE_FLYER_STATUS = 181818;
        public readonly static string ERROR_FAILED_TO_UPDATE_FLYER_STATUS_MSG = "Failed to Update Flyer Status";

        public readonly static int ERROR_FAILED_TO_GET_USERS_LIST = 191919;
        public readonly static string ERROR_FAILED_TO_GET_USERS_LIST_MSG = "Failed to Get Users List";

        public readonly static int ERROR_FAILED_TO_ADD_USER = 202020;
        public readonly static string ERROR_FAILED_TO_ADD_USER_MSG = "Failed to Add New User";

        public readonly static int ERROR_FAILED_GET_PRODUCT_MANUFACTURES = 212121;
        public readonly static string ERROR_FAILED_GET_PRODUCT_MANUFACTURES_MSG = "No Manufactures Found";

        public readonly static int ERROR_FAILED_GET_PRODUCT_BRANCHES = 222222;
        public readonly static string ERROR_FAILED_GET_PRODUCT_BRANCHES_MSG = "No Branches Found";

        public readonly static int ERROR_FAILED_GET_TYPE_SPECS = 232323;
        public readonly static string ERROR_FAILED_GET_TYPE_SPECS_MSG = "No Type Specs Found";

        public readonly static int ERROR_FAILED_GET_PRODUCT_OFFER_TYPES = 242424;
        public readonly static string ERROR_FAILED_GET_PRODUCT_OFFER_TYPES_MSG = "No Offer Types Found";
    }
}