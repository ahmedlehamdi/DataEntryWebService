using DataEntryDAL.DataAccessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataEntryDAL.Handlers
{
    public class ProvidersHandler
    {
        public List<PROVIDER> getAllProviders()
        {
            List<PROVIDER> allProviders = new List<PROVIDER>();
            using (DataClassesDataContext context = new DataClassesDataContext())
            {
                var result = (from a in context.GetTable<PROVIDER>()
                              select a);
                foreach (PROVIDER f in result)
                {
                    allProviders.Add(f);
                }
            }
            return allProviders;
        }
    }
}