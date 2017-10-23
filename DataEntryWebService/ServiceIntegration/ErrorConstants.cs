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
        public readonly static string ERROR_FAILED_TO_GET_FLYER_PRODUCTS_MSG = "Failed to retrieve Flyer Products";
    }
}