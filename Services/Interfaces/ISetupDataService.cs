using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyTrack.LaborSetup.Services.Interfaces
{
    interface ISetupDataService
    {
        List<string> GetBases();

        List<DateTime> GetTimes();
    }
}
