using SkyTrack.LaborSetup.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyTrack.LaborSetup.Services.Interfaces
{
    interface ILaborDataService
    {
        List<LaborData> GetLaborData(string Base, DateTime startTime, DateTime endTime);
    }
}
