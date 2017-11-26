using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataEntryDAL.CustomDataOBJ
{
    public class PRODUCT
    {
        public int PRODUCT_ID { get; set; }
        public int FLYER_ID { get; set; }
        public int Parent_ID { get; set; }
        public string PRODUCT_NAME_EN { get; set; }
        public string PRODUCT_NAME_AR { get; set; }
        public int PRODUCT_PRICE { get; set; }
        public int TYPE_ID { get; set; }
        public int CATEGORY_ID { get; set; }
        public int MANUFACTURE_ID { get; set; }
                                                        public List<PRODUCT_TYPE_SPECS> TYPE_SPECS { get; set; }
        public string PRODUCT_IMAGE { get; set; }
        public int BRANCH_ID { get; set; }
        public string PRODUCT_TAGS { get; set; }
        public DateTime DATE_FROM { get; set; }
        public DateTime DATE_TO { get; set; }
        public int PROD_OFF_TYPE_ID { get; set; }
        public int PROD_OFF_TYP_ATTR_ID { get; set; }
                                                        public PRODUCT_OFFER_TYPE_SPECS PROD_OFF_TYP_SPECS { get; set; }
                                                        public List<PRODUCT> bundleList { get; set; }
        public string PRODUCT_ATTR_1 { get; set; }
        public string PRODUCT_ATTR_2 { get; set; }
        public string PRODUCT_ATTR_3 { get; set; }
        public string PRODUCT_ATTR_4 { get; set; }
        public string PRODUCT_ATTR_5 { get; set; }
        public string PRODUCT_ATTR_6 { get; set; }
        public string PRODUCT_ATTR_7 { get; set; }
        public string PRODUCT_ATTR_8 { get; set; }
        public string PRODUCT_ATTR_9 { get; set; }
        public string PRODUCT_ATTR_10 { get; set; }
    }
}