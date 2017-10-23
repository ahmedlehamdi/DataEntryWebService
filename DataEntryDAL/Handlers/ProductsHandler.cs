using DataEntryDAL.DataAccessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataEntryDAL.Handlers
{
    public class ProductsHandler
    {

        public List<PRODUCTS_CATEGORy> getAllProductCategories()
        {
            List<PRODUCTS_CATEGORy> allCategories = new List<PRODUCTS_CATEGORy>();
            using (DataClassesDataContext context = new DataClassesDataContext())
            {
                var result = (context.PRODUCTS_CATEGORies.ToList());
                foreach (PRODUCTS_CATEGORy f in result)
                {
                    allCategories.Add(f);
                }
            }
            return allCategories;
        }

        public List<PRODUCT_TYPE> getAllCategoryTypes(int catID)
        {
            List<PRODUCT_TYPE> allTypes = new List<PRODUCT_TYPE>();
            using (DataClassesDataContext context = new DataClassesDataContext())
            {
                var result = (from a in context.GetTable<PRODUCT_TYPE>()
                              where a.CATEGORY_ID == catID
                              select a).ToList<PRODUCT_TYPE>();
                foreach (PRODUCT_TYPE f in result)
                {
                    allTypes.Add(f);
                }
            }
            return allTypes;
        }

        public int AddFlyerProduct(PRODUCT product, PRODUCT_SPEC specs)
        {
            try
            {
                using (DataClassesDataContext context = new DataClassesDataContext())
                {
                    context.PRODUCT_SPECs.InsertOnSubmit(specs);

                    context.SubmitChanges();

                    product.SPECS_ID = specs.SPECS_ID;

                    context.PRODUCTs.InsertOnSubmit(product);

                    context.SubmitChanges();

                    return product.PRODUCT_ID;
                }
            }catch(Exception ex)
            {
                return -1;
            }
        }

        public int AddFlyerAllProducts(List<PRODUCT> products, List<PRODUCT_SPEC> specs)
        {
            try
            {
                for (int i = 0; i < products.Count; i++)
                {
                    AddFlyerProduct(products.ElementAt(i), specs.ElementAt(i));
                }
                return 0;
            }catch(Exception ex)
            {
                return -1;
            }
        }

        public List<GET_FLYER_PRODUCTS_DATAResult> GET_FLYER_PRODUCTS(int fID)
        {

            using (DataClassesDataContext context = new DataClassesDataContext())
            {
                var result = context.GET_FLYER_PRODUCTS_DATA(fID).ToList<GET_FLYER_PRODUCTS_DATAResult>();
                return result;
            }
        }
    }
}