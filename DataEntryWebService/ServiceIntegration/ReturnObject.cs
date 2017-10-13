using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataEntryWebService.ServiceIntegration
{
    public class ReturnObject<OBJ>
    {
        public ReturnObject(int statusCode, OBJ obj)
        {
            this.statusCode = statusCode;
            this.returnObj = obj;
        }
        public int statusCode { get; set; }
        public OBJ returnObj { get; set; }
    }
}