using Microsoft.EntityFrameworkCore;
using MoviesAPIStore.MoviesContext;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MoviesAPIStore.Repository
{
    public class ValidateRequestConcrete : IValidateRequest
    {
        private DatabaseContext _context;

        public ValidateRequestConcrete(DatabaseContext context)
        {
            _context = context;
        }

        public bool ValidateKeys(string Key)
        {
            try
            {
                var result = (from apimanagertb in _context.APIManagerTB
                              where EF.Functions.Like(apimanagertb.APIKey, "%" + Key + "%")
                              select apimanagertb).Count();

                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool IsValidServiceRequest(string Key ,string ServiceName)
        {
            try
            {
                var serviceID = (from apimanagertb in _context.APIManagerTB
                              where EF.Functions.Like(apimanagertb.APIKey, "%" + Key + "%")
                              select apimanagertb.ServiceID).FirstOrDefault();

                var serviceName = (from servicestb in _context.ServicesTB
                                 where servicestb.ServiceID == serviceID
                                   select servicestb.APIName).FirstOrDefault();

                if (string.Equals(ServiceName, serviceName,StringComparison.InvariantCultureIgnoreCase))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool ValidateIsServiceActive(string Key)
        {
            try
            {
                var result = (from apimanagertb in _context.APIManagerTB
                              where EF.Functions.Like(apimanagertb.APIKey, "%" + Key + "%") && apimanagertb.Status == "A"
                              select apimanagertb).Count();

                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        //public bool CalculateCountofRequest(string Key)
        //{
        //    try
        //    {

        //        var totalRequestCount = (from apimanagertb in _context.APIManagerTB
        //                      join hittb in _context.HitsTB on apimanagertb.HitsID equals hittb.HitsID
        //                      where apimanagertb.APIKey == Key
        //                      select hittb.Hits).FirstOrDefault();

        //        var totalCurrentRequestCount = (from loggertb in _context.LoggerTB
        //                      where loggertb.APIKey == Key
        //                      select loggertb).Count();

        //        if (totalCurrentRequestCount >= totalRequestCount)
        //        {
        //            return false;
        //        }
        //        else
        //        {
        //            return true;
        //        }

        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}
    }
}
