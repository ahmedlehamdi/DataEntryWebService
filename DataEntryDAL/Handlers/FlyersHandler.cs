using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataEntryDAL.DataAccessLogic;

namespace DataEntryDAL.Handlers
{
    public class FlyersHandler
    {

        public List<GET_ALL_FLYERS_PROCDResult> getAllFlyers(int userID)
        {
            List<GET_ALL_FLYERS_PROCDResult> allFlyers = new List<GET_ALL_FLYERS_PROCDResult>();
            using (DataClassesDataContext context = new DataClassesDataContext())
            {
                var user = context.Users.Single(x => x.USER_ID == userID);
                if(user.USER_TYPE == "DataEntry")
                {
                    var result = context.GET_ALL_FLYERS_PROCD(userID);
                    foreach (GET_ALL_FLYERS_PROCDResult f in result)
                    {
                        allFlyers.Add(f);
                    }
                }
                else if (user.USER_TYPE == "Admin" || user.USER_TYPE == "SuperAdmin")
                {
                    var result = context.GET_ALL_USER_ALL_FLYERS();
                    foreach (GET_ALL_USER_ALL_FLYERSResult f in result)
                    {
                        GET_ALL_FLYERS_PROCDResult x = new GET_ALL_FLYERS_PROCDResult();
                        x.FLYER_APPROVED = f.FLYER_APPROVED;
                        x.FLYER_ID = f.FLYER_ID;
                        x.FLYER_IMAGE_URL = f.FLYER_IMAGE_URL;
                        x.FLYER_NAME_AR = f.FLYER_NAME_AR;
                        x.FLYER_NAME_EN = f.FLYER_NAME_EN;
                        x.FRAME_DATE_FROM = f.FRAME_DATE_FROM;
                        x.FRAME_DATE_TO = f.FRAME_DATE_TO;
                        x.FRAME_NAME_AR = f.FRAME_NAME_AR;
                        x.FRAME_NAME_EN = f.FRAME_NAME_EN;
                        x.LOCATION_CITY = f.LOCATION_CITY;
                        x.LOCATION_DISTRICT = f.LOCATION_DISTRICT;
                        x.OFFER_TYPE_NAME_AR = f.OFFER_TYPE_NAME_AR;
                        x.OFFER_TYPE_NAME_EN = f.OFFER_TYPE_NAME_EN;
                        x.PROVIDER_NAME_AR = f.PROVIDER_NAME_AR;
                        x.PROVIDER_NAME_EN = f.PROVIDER_NAME_EN;
                        allFlyers.Add(x);
                    }
                }
                
            }
            return allFlyers;
        }

        public List<OFFER_TYPE> getAllOfferTypes()
        {
            List<OFFER_TYPE> allFlyers = new List<OFFER_TYPE>();
            using (DataClassesDataContext context = new DataClassesDataContext())
            {
                var result = (from a in context.GetTable<OFFER_TYPE>()
                              select a); ;
                foreach (OFFER_TYPE f in result)
                {
                    allFlyers.Add(f);
                }
            }
            return allFlyers;
        }

        public int AddNewFlyer(OFFER_FLYER flyer, TIME_FRAME frame, string action)
        {
            using (DataClassesDataContext context = new DataClassesDataContext())
            {
                if(action == "insert")
                {
                    context.TIME_FRAMEs.InsertOnSubmit(frame);

                    context.SubmitChanges();

                    flyer.FRAME_ID = frame.FRAME_ID;

                    flyer.FLYER_APPROVED = null;

                    context.OFFER_FLYERs.InsertOnSubmit(flyer);

                    context.SubmitChanges();

                    return flyer.FLYER_ID;
                }
                else if(action == "update")
                {
                    TIME_FRAME objFrame = context.TIME_FRAMEs.Single(x => x.FRAME_ID == frame.FRAME_ID);
                    objFrame.FRAME_NAME_EN = frame.FRAME_NAME_EN;
                    objFrame.FRAME_NAME_AR = frame.FRAME_NAME_AR;
                    objFrame.FRAME_TYPE_ID = frame.FRAME_TYPE_ID;
                    objFrame.FRAME_DATE_TO = frame.FRAME_DATE_TO;
                    objFrame.FRAME_DATE_FROM = frame.FRAME_DATE_FROM;

                    context.SubmitChanges();

                    OFFER_FLYER objFlyer = context.OFFER_FLYERs.Single(x => x.FLYER_ID == flyer.FLYER_ID);
                    objFlyer.FLYER_NAME_AR = flyer.FLYER_NAME_AR;
                    objFlyer.FLYER_NAME_EN = flyer.FLYER_NAME_EN;
                    objFlyer.OFFER_TYPE_ID = flyer.OFFER_TYPE_ID;
                    objFlyer.FRAME_ID = frame.FRAME_ID;
                    objFlyer.FLYER_IMAGE_URL = flyer.FLYER_IMAGE_URL;
                    objFlyer.PROVIDER_ID = flyer.PROVIDER_ID;

                    context.SubmitChanges();

                    return flyer.FLYER_ID;
                }
                else
                {
                    return -1;
                }
            }
        }


        public GET_FLYER_BASIC_DATAResult GET_FLYER_DATA(int fID)
        {
            
            using (DataClassesDataContext context = new DataClassesDataContext())
            {
                var result = context.GET_FLYER_BASIC_DATA(fID).FirstOrDefault();
                return result;
            }
        }

        public int deleteFlyerByID(int flyerID)
        {
            try
            {
                using (DataClassesDataContext context = new DataClassesDataContext())
                {
                    var deleteFlyer =
                                from flyers in context.OFFER_FLYERs
                                where flyers.FLYER_ID == flyerID
                                select flyers;

                    foreach (var x in deleteFlyer)
                    {
                        context.OFFER_FLYERs.DeleteOnSubmit(x);
                    }

                    var deleteFlyerProducts =
                                from products in context.PRODUCTs
                                where products.FLYER_ID == flyerID
                                select products;

                    foreach (var x in deleteFlyerProducts)
                    {
                        context.PRODUCTs.DeleteOnSubmit(x);
                    }
                    context.SubmitChanges();
                    return flyerID;
                }
            }catch(Exception e)
            {
                return -1;
            }
        }


        public int approveRejectFlyer(int flyerID, bool flag)
        {
            try
            {
                using (DataClassesDataContext context = new DataClassesDataContext())
                {
                    var flyer = (from a in context.GetTable<OFFER_FLYER>()
                                where (a.FLYER_ID == flyerID)
                                select a).FirstOrDefault<OFFER_FLYER>();
                    if (flyer != null)
                    {
                        flyer.FLYER_APPROVED = flag;
                        context.SubmitChanges();
                    }
                }
                return flyerID;
            }
            catch (Exception e)
            {
                return -1;
            }
        }
    }
}