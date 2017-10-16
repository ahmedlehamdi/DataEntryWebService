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

    }
}