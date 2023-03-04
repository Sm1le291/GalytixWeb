using GalytixWeb.DataAccess.Abstractions;
using GalytixWeb.DataAccess.Models;
using GalytixWeb.Services.Abstractions;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GalytixWeb.Services
{
    public class GWPService : IGWPService
    {
        private readonly IGWPRepository _gwpRepository;

        public GWPService(IGWPRepository gwpRepository)
        {
            _gwpRepository = gwpRepository;
        }



        public async Task<Dictionary<string, double>> CalculateForCountryAndLob(string country, IEnumerable<string> lob)
        {
            var rows = await _gwpRepository.GetByCountryAndLob(country, lob);
            Dictionary<string, double> result = new Dictionary<string, double>();

            rows.ToList().ForEach(r =>
            {
                var totalNumberOfYears = (double)GetTotalNumberOfYears(r);
                var total = GetValue(r.Y2008) + GetValue(r.Y2009) + GetValue(r.Y2010) + GetValue(r.Y2011) + GetValue(r.Y2012) + GetValue(r.Y2013) + GetValue(r.Y2014) + GetValue(r.Y2015);
                result.Add(r.LineOfBusiness, total / totalNumberOfYears);
            });

            return result;
        }

        private double GetValue(double? val)
        {
            return val.HasValue ? val.Value : 0;
        }

        private double GetTotalNumberOfYears(GWPItem item)
        {
            int total = 0;

            if (item.Y2008.HasValue) ++total;
            if (item.Y2009.HasValue) ++total;
            if (item.Y2010.HasValue) ++total;
            if (item.Y2011.HasValue) ++total;
            if (item.Y2012.HasValue) ++total;
            if (item.Y2013.HasValue) ++total;
            if (item.Y2014.HasValue) ++total;
            if (item.Y2015.HasValue) ++total;

            return total;
        }
    }
}
