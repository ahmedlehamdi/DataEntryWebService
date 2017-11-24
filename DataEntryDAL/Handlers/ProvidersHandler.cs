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

        public List<GET_ALL_BRANCHESResult> getAllProductBranches(int parentID)
        {
            List<GET_ALL_BRANCHESResult> allBranches = new List<GET_ALL_BRANCHESResult>();
            using (DataClassesDataContext context = new DataClassesDataContext())
            {
                var result = (context.GET_ALL_BRANCHES(parentID).ToList());
                foreach (GET_ALL_BRANCHESResult f in result)
                {
                    allBranches.Add(f);
                }
            }
            return allBranches;
        }

    }
}