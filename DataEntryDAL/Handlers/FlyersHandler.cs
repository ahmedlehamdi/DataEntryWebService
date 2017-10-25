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
                var result = context.GET_ALL_FLYERS_PROCD(userID);
                foreach (GET_ALL_FLYERS_PROCDResult f in result)
                {
                    allFlyers.Add(f);
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
    }
}