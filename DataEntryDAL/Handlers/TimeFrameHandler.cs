using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataEntryDAL.DataAccessLogic;

namespace DataEntryDAL.Handlers
{
    public class TimeFrameHandler
    {
        public List<TIME_FRAMES_TYPE> getAllTimeFrames()
        {
            List<TIME_FRAMES_TYPE> allFrames = new List<TIME_FRAMES_TYPE>();
            using (DataClassesDataContext context = new DataClassesDataContext())
            {
                var result = (from a in context.GetTable<TIME_FRAMES_TYPE>()
                              select a).ToList<TIME_FRAMES_TYPE>();
                foreach (TIME_FRAMES_TYPE f in result)
                {
                    allFrames.Add(f);
                }
            }
            return allFrames;
        }
    }
}