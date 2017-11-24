using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataEntryDAL.DataAccessLogic;


namespace DataEntryDAL.Handlers
{
    public class ManufactuerHandler
    {
        public List<MANUFACTURE> getAllProductManufactures()
        {
            List<MANUFACTURE> allMnuf = new List<MANUFACTURE>();
            using (DataClassesDataContext context = new DataClassesDataContext())
            {
                var result = (context.MANUFACTUREs.ToList());
                foreach (MANUFACTURE f in result)
                {
                    allMnuf.Add(f);
                }
            }
            return allMnuf;
        }

        
    }
}