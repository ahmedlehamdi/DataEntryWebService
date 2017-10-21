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

        public int AddNewFlyer(OFFER_FLYER flyer, TIME_FRAME frame)
        {
            using (DataClassesDataContext context = new DataClassesDataContext())
            {
                context.TIME_FRAMEs.InsertOnSubmit(frame);

                context.SubmitChanges();

                flyer.FRAME_ID = frame.FRAME_ID;

                context.OFFER_FLYERs.InsertOnSubmit(flyer);

                context.SubmitChanges();

                return flyer.FLYER_ID;
            }
        }

    }
}