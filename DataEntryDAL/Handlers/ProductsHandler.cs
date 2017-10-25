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
                    deleteProduct(products.ElementAt(i), specs.ElementAt(i));
                    AddFlyerProduct(products.ElementAt(i), specs.ElementAt(i));
                }
                return 0;
            }catch(Exception ex)
            {
                return -1;
            }
        }

        public void deleteProduct(PRODUCT prod, PRODUCT_SPEC spec)
        {
            try
            {
                using (DataClassesDataContext context = new DataClassesDataContext())
                {
                    var deleteSpecs =
                            from specs in context.PRODUCT_SPECs
                            where specs.SPECS_ATTR_1 == spec.SPECS_ATTR_1
                            select specs;

                    foreach (var x in deleteSpecs)
                    {
                        context.PRODUCT_SPECs.DeleteOnSubmit(x);
                    }

                    var deleteProduct =
                            from product in context.PRODUCTs
                            where product.PRODUCT_NAME_EN == prod.PRODUCT_NAME_EN
                            select product;

                    foreach (var y in deleteProduct)
                    {
                        context.PRODUCTs.DeleteOnSubmit(y);
                    }

                    try
                    {
                        context.SubmitChanges();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        // Provide for exceptions.
                    }
                }
            }
            catch (Exception ex)
            {
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