using DataEntryDAL.DataAccessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataEntryDAL.Handlers
{
    public class ProvidersHandler
    {
        public List<GET_ALL_PROVIDERSResult> getAllProviders()
        {
            List<GET_ALL_PROVIDERSResult> allProviders = new List<GET_ALL_PROVIDERSResult>();
            using (DataClassesDataContext context = new DataClassesDataContext())
            {
                var result = context.GET_ALL_PROVIDERS().ToList<GET_ALL_PROVIDERSResult>();
                              
                foreach (GET_ALL_PROVIDERSResult f in result)
                {
                    allProviders.Add(f);
                }
            }
            return allProviders;
        }
    }
}