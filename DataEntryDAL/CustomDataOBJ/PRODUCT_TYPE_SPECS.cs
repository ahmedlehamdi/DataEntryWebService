using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataEntryDAL.CustomDataOBJ
{
    public class PRODUCT_TYPE_SPECS
    {
        public int TYPE_SPECS_ID { get; set; }
        public int TEMPLATE_ID { get; set; }
        public string TEMPLATE_VALUE { get; set; }
        public int TYPE_ID { get; set; }
        public int PRODUCT_ID { get; set; }
    }
}