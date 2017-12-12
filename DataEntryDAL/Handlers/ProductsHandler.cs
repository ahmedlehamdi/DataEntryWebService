using DataEntryDAL.DataAccessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataEntryDAL.Handlers
{
    public class ProductsHandler
    {
        private int productParentID = -1;

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
        public List<PROD_TYPE_TEMPLATE> getAllTypeSpecs(int typeID)
        {
            List<PROD_TYPE_TEMPLATE> allTypes = new List<PROD_TYPE_TEMPLATE>();
            using (DataClassesDataContext context = new DataClassesDataContext())
            {
                var result = (from a in context.GetTable<PROD_TYPE_TEMPLATE>()
                              where a.TYPE_ID == typeID
                              select a).ToList<PROD_TYPE_TEMPLATE>();
                foreach (PROD_TYPE_TEMPLATE f in result)
                {
                    allTypes.Add(f);
                }
            }
            return allTypes;
        }
      
        public List<GET_FLYER_PRODUCTS_DATAResult> GET_FLYER_PRODUCTS(int fID)
        {

            using (DataClassesDataContext context = new DataClassesDataContext())
            {
                var result = context.GET_FLYER_PRODUCTS_DATA(fID).ToList<GET_FLYER_PRODUCTS_DATAResult>();
                return result;
            }
        }

        public List<PROD_OFF_TYP> RETRIEVE_ALL_PRODUCT_OFFER_TYPES()
        {

            using (DataClassesDataContext context = new DataClassesDataContext())
            {
                var result = context.PROD_OFF_TYPs.ToList();
                return result;
            }
        }



        public int INSERT_ALL_PRODUCTS(List<DataEntryDAL.CustomDataOBJ.PRODUCT> productsList)
        {
            try
            {
                using (DataClassesDataContext context = new DataClassesDataContext())
                {
                    var prodID = -1;
                    deleteProduct(productsList[0].FLYER_ID);
                    foreach (var prod in productsList)
                    {
                        var offerAttrID = 0;
                        // Add Product
                        PRODUCT product = new PRODUCT();

                        product.PRODUCT_NAME_EN = prod.PRODUCT_NAME_EN;
                        product.PRODUCT_NAME_AR = prod.PRODUCT_NAME_AR;

                        product.FLYER_ID = prod.FLYER_ID;
                        product.Parent_ID = productParentID;
                        product.TYPE_ID = prod.TYPE_ID;
                        product.BRANCH_ID = prod.BRANCH_ID;
                        product.MANUFACTURE_ID = prod.MANUFACTURE_ID;

                        product.PRODUCT_IMAGE = prod.PRODUCT_IMAGE;
                        product.PRODUCT_PRICE = prod.PRODUCT_PRICE.ToString();
                        product.PRODUCT_TAGS = prod.PRODUCT_TAGS;

                        product.DATE_FROM = prod.DATE_FROM;
                        product.DATE_TO = prod.DATE_TO;

                        product.PRODUCT_ATTR_1 = prod.PRODUCT_ATTR_1;
                        product.PRODUCT_ATTR_2 = prod.PRODUCT_ATTR_2;
                        product.PRODUCT_ATTR_3 = prod.PRODUCT_ATTR_3;
                        product.PRODUCT_ATTR_4 = prod.PRODUCT_ATTR_4;
                        product.PRODUCT_ATTR_5 = prod.PRODUCT_ATTR_5;

                        // Submit Product
                        context.PRODUCTs.InsertOnSubmit(product);
                        context.SubmitChanges();

                        prodID = product.PRODUCT_ID;

                        // Add TYPE_SPECS       prod.TYPE_SPECS
                        foreach (CustomDataOBJ.PRODUCT_TYPE_SPECS spec in prod.TYPE_SPECS)
                        {
                            PROD_TYPE_SPEC specs = new PROD_TYPE_SPEC();
                            specs.TEMPLATE_ID = spec.TEMPLATE_ID;
                            specs.TEMPLATE_VALUE = spec.TEMPLATE_VALUE;
                            specs.TYPE_ID = spec.TYPE_ID;
                            specs.PRODUCT_ID = prodID;
                            context.PROD_TYPE_SPECs.InsertOnSubmit(specs);
                        }
                        context.SubmitChanges();


                        // Adding OFFER TYPE SPECS
                        PROD_OFF_TYP_ATTR offerTypeAttr = new PROD_OFF_TYP_ATTR();
                        // CASE 1 : BUNDLE
                        if (prod.bundleList != null && prod.bundleList.Count > 0)
                        {
                            productParentID = prodID;
                            foreach (var p in prod.bundleList)
                            {
                                List<DataEntryDAL.CustomDataOBJ.PRODUCT> list = new List<CustomDataOBJ.PRODUCT>();
                                list.Add(p);
                                var prID = INSERT_ALL_PRODUCTS(list);

                                if (offerTypeAttr.PROD_OFF_TYP_ATTR_1 == null || offerTypeAttr.PROD_OFF_TYP_ATTR_1 == "")
                                    offerTypeAttr.PROD_OFF_TYP_ATTR_1 = prID.ToString();

                                else if (offerTypeAttr.PROD_OFF_TYP_ATTR_2 == null || offerTypeAttr.PROD_OFF_TYP_ATTR_2 == "")
                                    offerTypeAttr.PROD_OFF_TYP_ATTR_2 = prID.ToString();

                                else if (offerTypeAttr.PROD_OFF_TYP_ATTR_3 == null || offerTypeAttr.PROD_OFF_TYP_ATTR_3 == "")
                                    offerTypeAttr.PROD_OFF_TYP_ATTR_3 = prID.ToString();

                                else if (offerTypeAttr.PROD_OFF_TYP_ATTR_4 == null || offerTypeAttr.PROD_OFF_TYP_ATTR_4 == "")
                                    offerTypeAttr.PROD_OFF_TYP_ATTR_4 = prID.ToString();

                                else if (offerTypeAttr.PROD_OFF_TYP_ATTR_5 == null || offerTypeAttr.PROD_OFF_TYP_ATTR_5 == "")
                                    offerTypeAttr.PROD_OFF_TYP_ATTR_5 = prID.ToString();

                                else if (offerTypeAttr.PROD_OFF_TYP_ATTR_6 == null || offerTypeAttr.PROD_OFF_TYP_ATTR_6 == "")
                                    offerTypeAttr.PROD_OFF_TYP_ATTR_6 = prID.ToString();

                                else if (offerTypeAttr.PROD_OFF_TYP_ATTR_7 == null || offerTypeAttr.PROD_OFF_TYP_ATTR_7 == "")
                                    offerTypeAttr.PROD_OFF_TYP_ATTR_7 = prID.ToString();

                                else if (offerTypeAttr.PROD_OFF_TYP_ATTR_8 == null || offerTypeAttr.PROD_OFF_TYP_ATTR_8 == "")
                                    offerTypeAttr.PROD_OFF_TYP_ATTR_8 = prID.ToString();

                                else if (offerTypeAttr.PROD_OFF_TYP_ATTR_9 == null || offerTypeAttr.PROD_OFF_TYP_ATTR_9 == "")
                                    offerTypeAttr.PROD_OFF_TYP_ATTR_9 = prID.ToString();

                                else if (offerTypeAttr.PROD_OFF_TYP_ATTR_10 == null || offerTypeAttr.PROD_OFF_TYP_ATTR_10 == "")
                                    offerTypeAttr.PROD_OFF_TYP_ATTR_10 = prID.ToString();
                            }
                            offerTypeAttr.PROD_OFF_TYPE_ID = 5;
                            productParentID = -1;
                        }
                        // CASE 2 : NON-BUNLDE
                        else
                        {
                            offerTypeAttr.PROD_OFF_TYPE_ID = prod.PROD_OFF_TYP_SPECS.PROD_OFF_TYPE_ID;
                            offerTypeAttr.PROD_OFF_TYP_ATTR_1 = prod.PROD_OFF_TYP_SPECS.PROD_OFF_TYP_ATTR_1;
                            offerTypeAttr.PROD_OFF_TYP_ATTR_2 = prod.PROD_OFF_TYP_SPECS.PROD_OFF_TYP_ATTR_2;
                            offerTypeAttr.PROD_OFF_TYP_ATTR_3 = prod.PROD_OFF_TYP_SPECS.PROD_OFF_TYP_ATTR_3;
                            offerTypeAttr.PROD_OFF_TYP_ATTR_4 = prod.PROD_OFF_TYP_SPECS.PROD_OFF_TYP_ATTR_4;
                            offerTypeAttr.PROD_OFF_TYP_ATTR_5 = prod.PROD_OFF_TYP_SPECS.PROD_OFF_TYP_ATTR_5;
                            offerTypeAttr.PROD_OFF_TYP_ATTR_6 = prod.PROD_OFF_TYP_SPECS.PROD_OFF_TYP_ATTR_6;
                            offerTypeAttr.PROD_OFF_TYP_ATTR_7 = prod.PROD_OFF_TYP_SPECS.PROD_OFF_TYP_ATTR_7;
                            offerTypeAttr.PROD_OFF_TYP_ATTR_8 = prod.PROD_OFF_TYP_SPECS.PROD_OFF_TYP_ATTR_8;
                            offerTypeAttr.PROD_OFF_TYP_ATTR_9 = prod.PROD_OFF_TYP_SPECS.PROD_OFF_TYP_ATTR_9;
                            offerTypeAttr.PROD_OFF_TYP_ATTR_10 = prod.PROD_OFF_TYP_SPECS.PROD_OFF_TYP_ATTR_10;
                        }

                        // SUBMIT OFFER TYPE ATTR
                        context.PROD_OFF_TYP_ATTRs.InsertOnSubmit(offerTypeAttr);
                        context.SubmitChanges();
                        offerAttrID = offerTypeAttr.PROD_OFF_TYP_ATTR_ID;

                        var query =
                                from obj in context.GetTable<PRODUCT>()
                                where obj.PRODUCT_ID == prodID
                                select obj;
                        query.FirstOrDefault().PROD_OFF_TYP_ATTR_ID = offerAttrID;
                        context.SubmitChanges();
                    }
                    return prodID;
                }
            }catch(Exception ex)
            {
                return -1;
            }
        }

        public void deleteProduct(int flyerID)
        {
            try
            {
                using (DataClassesDataContext context = new DataClassesDataContext())
                {
                    var query =
                               (from obj in context.PRODUCTs
                                where obj.FLYER_ID == flyerID
                                select obj).ToList();
                    foreach (var prod in query)
                    {

                        var Specs =
                                from s in context.PROD_TYPE_SPECs
                                where s.PRODUCT_ID == prod.PRODUCT_ID
                                select s;

                        foreach (var x in Specs)
                        {
                            context.PROD_TYPE_SPECs.DeleteOnSubmit(x);
                        }

                        context.SubmitChanges();

                        var attrs =
                               from a in context.PROD_OFF_TYP_ATTRs
                               where a.PROD_OFF_TYP_ATTR_ID == prod.PROD_OFF_TYP_ATTR_ID
                               select a;

                        foreach (var x in attrs)
                        {
                            context.PROD_OFF_TYP_ATTRs.DeleteOnSubmit(x);
                        }

                        context.SubmitChanges();

                        var deleteProduct =
                                from product in context.PRODUCTs
                                where product.PRODUCT_ID == prod.PRODUCT_ID
                                select product;

                        foreach (var y in deleteProduct)
                        {
                            context.PRODUCTs.DeleteOnSubmit(y);
                        }

                        context.SubmitChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
        }


        public List<CustomDataOBJ.PRODUCT> getProductsList(int flyerID, int parentID)
        {
            try
            {
                using (DataClassesDataContext context = new DataClassesDataContext())
                {
                    var query =
                               (from obj in context.PRODUCTs
                               where obj.FLYER_ID == flyerID & obj.Parent_ID == parentID
                                select obj);
                    var productList = new List<CustomDataOBJ.PRODUCT>();

                    foreach (var p in query)
                    {
                        CustomDataOBJ.PRODUCT product = new CustomDataOBJ.PRODUCT();

                        product.PRODUCT_ID = p.PRODUCT_ID;
                        product.FLYER_ID = p.FLYER_ID;
                        product.Parent_ID = p.Parent_ID.GetValueOrDefault();
                        product.PRODUCT_NAME_EN = p.PRODUCT_NAME_EN;
                        product.PRODUCT_NAME_AR = p.PRODUCT_NAME_AR;
                        product.PRODUCT_PRICE = float.Parse(p.PRODUCT_PRICE);
                        product.TYPE_ID = p.TYPE_ID;

                        //product.CATEGORY_ID = p.CATEGORY_ID;
                        var type = (from obj in context.GetTable<PRODUCT_TYPE>()
                                     where obj.TYPE_ID == p.TYPE_ID
                                     select obj).FirstOrDefault();
                        product.CATEGORY_ID = type.CATEGORY_ID;
                        product.TYPE_NAME_EN = type.TYPE_NAME_EN;
                        product.TYPE_NAME_AR = type.TYPE_NAME_AR;


                        var cat = (from obj in context.GetTable<PRODUCTS_CATEGORy>()
                                    where obj.CATEGORY_ID == type.CATEGORY_ID
                                    select obj).FirstOrDefault();
                        product.CATEGORY_NAME_EN = cat.CATEGORY_NAME_EN;
                        product.CATEGORY_NAME_AR = cat.CATEGORY_NAME_AR;


                        product.MANUFACTURE_ID = int.Parse(p.MANUFACTURE_ID.ToString());
                        var manu = (from obj in context.GetTable<MANUFACTURE>()
                                   where obj.MANUFACTURE_ID == int.Parse(p.MANUFACTURE_ID.ToString())
                                      select obj).FirstOrDefault();
                        product.MANUFACTURE_NAME_EN = manu.MANUFACTURE_NAME_EN;
                        product.MANUFACTURE_NAME_AR = manu.MANUFACTURE_NAME_AR;


                        product.PRODUCT_IMAGE = p.PRODUCT_IMAGE;
                        product.BRANCH_ID = p.BRANCH_ID.GetValueOrDefault();
                        var branch = (from obj in context.GetTable<PROVIDER>()
                                    where obj.PROVIDER_ID == p.BRANCH_ID.GetValueOrDefault()
                                      select obj).FirstOrDefault();
                        product.BRANCH_NAME_EN = branch.PROVIDER_NAME_EN;
                        product.BRANCH_NAME_AR = branch.PROVIDER_NAME_AR;

                        product.PRODUCT_TAGS = p.PRODUCT_TAGS;
                        product.DATE_FROM = p.DATE_FROM.GetValueOrDefault();
                        product.DATE_TO = p.DATE_TO.GetValueOrDefault();

                        //product.PROD_OFF_TYPE_ID = p.PROD_OFF_TYPE_ID.GetValueOrDefault();
                        var offerTypeID = (from obj in context.GetTable<PROD_OFF_TYP_ATTR>()
                                     where obj.PROD_OFF_TYP_ATTR_ID == p.PROD_OFF_TYP_ATTR_ID
                                           select obj).FirstOrDefault().PROD_OFF_TYPE_ID;
                        product.PROD_OFF_TYPE_ID = offerTypeID.GetValueOrDefault();

                        var offerTypeObj = (from obj in context.GetTable<PROD_OFF_TYP>()
                                           where obj.PROD_OFF_TYPE_ID == offerTypeID
                                           select obj).FirstOrDefault();
                        product.PROD_OFF_TYPE_NAME_EN = offerTypeObj.PROD_OFF_TYPE_NAME_EN;
                        product.PROD_OFF_TYPE_NAME_AR = offerTypeObj.PROD_OFF_TYPE_NAME_AR;

                        product.PROD_OFF_TYP_ATTR_ID = p.PROD_OFF_TYP_ATTR_ID.GetValueOrDefault();

                        product.PRODUCT_ATTR_1 = p.PRODUCT_ATTR_1;
                        product.PRODUCT_ATTR_2 = p.PRODUCT_ATTR_2;
                        product.PRODUCT_ATTR_3 = p.PRODUCT_ATTR_3;
                        product.PRODUCT_ATTR_4 = p.PRODUCT_ATTR_4;
                        product.PRODUCT_ATTR_5 = p.PRODUCT_ATTR_5;

                        ///// Product Type Specs
                        List<CustomDataOBJ.PRODUCT_TYPE_SPECS> specs = new List<CustomDataOBJ.PRODUCT_TYPE_SPECS>();
                        var prodSpecsList = (from obj in context.GetTable<PROD_TYPE_SPEC>()
                                             where obj.PRODUCT_ID == p.PRODUCT_ID
                                             select obj);
                        foreach(var spec in prodSpecsList)
                        {
                            CustomDataOBJ.PRODUCT_TYPE_SPECS s = new CustomDataOBJ.PRODUCT_TYPE_SPECS();
                            s.PRODUCT_ID = spec.PRODUCT_ID.GetValueOrDefault();
                            s.TEMPLATE_ID = spec.TEMPLATE_ID.GetValueOrDefault();
                            s.TEMPLATE_VALUE = spec.TEMPLATE_VALUE;
                            s.TYPE_ID = spec.TYPE_ID.GetValueOrDefault();
                            s.TYPE_SPECS_ID = spec.TYPE_SPECS_ID;
                            specs.Add(s);
                        }
                        product.TYPE_SPECS = specs;


                        //PRODUCT_OFFER_TYPE_SPECS
                        CustomDataOBJ.PRODUCT_OFFER_TYPE_SPECS offerSpecs = new CustomDataOBJ.PRODUCT_OFFER_TYPE_SPECS();
                        var prodOfferSpecs = (from obj in context.GetTable<PROD_OFF_TYP_ATTR>()
                                             where obj.PROD_OFF_TYP_ATTR_ID == p.PROD_OFF_TYP_ATTR_ID
                                              select obj).FirstOrDefault();
                        offerSpecs.PROD_OFF_TYPE_ID = prodOfferSpecs.PROD_OFF_TYPE_ID.GetValueOrDefault();
                        offerSpecs.PROD_OFF_TYP_ATTR_1 = prodOfferSpecs.PROD_OFF_TYP_ATTR_1;
                        offerSpecs.PROD_OFF_TYP_ATTR_2 = prodOfferSpecs.PROD_OFF_TYP_ATTR_2;
                        offerSpecs.PROD_OFF_TYP_ATTR_3 = prodOfferSpecs.PROD_OFF_TYP_ATTR_3;
                        offerSpecs.PROD_OFF_TYP_ATTR_4 = prodOfferSpecs.PROD_OFF_TYP_ATTR_4;
                        offerSpecs.PROD_OFF_TYP_ATTR_5 = prodOfferSpecs.PROD_OFF_TYP_ATTR_5;
                        offerSpecs.PROD_OFF_TYP_ATTR_6 = prodOfferSpecs.PROD_OFF_TYP_ATTR_6;
                        offerSpecs.PROD_OFF_TYP_ATTR_7 = prodOfferSpecs.PROD_OFF_TYP_ATTR_7;
                        offerSpecs.PROD_OFF_TYP_ATTR_8 = prodOfferSpecs.PROD_OFF_TYP_ATTR_8;
                        offerSpecs.PROD_OFF_TYP_ATTR_9 = prodOfferSpecs.PROD_OFF_TYP_ATTR_9;
                        offerSpecs.PROD_OFF_TYP_ATTR_10 = prodOfferSpecs.PROD_OFF_TYP_ATTR_10;

                        product.PROD_OFF_TYP_SPECS = offerSpecs;


                        /// Bundle List 
                        if(prodOfferSpecs.PROD_OFF_TYPE_ID == 5)
                        {
                            product.bundleList = getProductsList(p.FLYER_ID, p.PRODUCT_ID);
                        }

                        productList.Add(product);
                    }

                    return productList;
                }
            }catch(Exception e)
            {
                return null;
            }
        }

    }
}