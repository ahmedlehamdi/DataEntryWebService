using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataEntryDAL.DataAccessLogic;

namespace DataEntryDAL.Handlers
{
    public class TimeFrameHandler
    {
        public List<TIME_FRAME> getAllTimeFrames()
        {
            List<TIME_FRAME> allFrames = new List<TIME_FRAME>();
            using (DataClassesDataContext context = new DataClassesDataContext())
            {
                var result = (from a in context.GetTable<TIME_FRAME>()
                              select a);
                foreach (TIME_FRAME f in result)
                {
                    allFrames.Add(f);
                }
            }
            return allFrames;
        }
    }
}