using SkyTrack.LaborSetup.Models;
using SkyTrack.LaborSetup.Services.Interfaces;
using SkyTrack.LaborSetup.Services.MockProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyTrack.LaborSetup.Repositories
{
    class LaborSetupRepository
    {
        ISetupDataService setupDataService = null;
        ILaborDataService laborDataService = null;

        public LaborSetupRepository(bool useMockData=false)
        {
            if (useMockData)
            {
                setupDataService = new MockSetupDataService();
                laborDataService = new MockLaborDataService();
            } else
            {
                //create SQL services here
            }
        }

        public List<string> GetBases()
        {
            List<string> Bases = setupDataService.GetBases();
            Bases.Insert(0, "Select a Base"); //default value
            return Bases;
        }

        public List<DateTime> GetTimes()
        {
            return setupDataService.GetTimes();
        }

        public List<LaborData> GetLaborData(string Base, DateTime startTime, DateTime endTime)
        {
            return laborDataService.GetLaborData(Base, startTime, endTime);
        }
    }
}
