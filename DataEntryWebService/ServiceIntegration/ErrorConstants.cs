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
    }
}