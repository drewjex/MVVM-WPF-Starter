using SkyTrack.LaborSetup.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyTrack.LaborSetup.Services.MockProviders
{
    class MockSetupDataService : ISetupDataService
    {
        public List<string> GetBases()
        {
            List<string> list = new List<string>();

            list.Add("SLC");
            list.Add("DEN");
            list.Add("LAX");
            list.Add("SGU");
            list.Add("CDC");
            list.Add("SEA");

            return list;
        }

        public List<DateTime> GetTimes()
        {
            List<DateTime> list = new List<DateTime>();

            list = GetTimeRange(DateTime.Parse("00:00"), DateTime.Parse("23:30"), 30).ToList();

            return list;
        }

        public IEnumerable<DateTime> GetTimeRange(DateTime startTime, DateTime endTime, int minutesBetween)
        {
            int periods = (int)(endTime - startTime).TotalMinutes / minutesBetween;
            return Enumerable.Range(0, periods + 1)
                             .Select(p => startTime.AddMinutes(minutesBetween * p));
        }
    }
}
