using SkyTrack.LaborSetup.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkyTrack.LaborSetup.Models;

namespace SkyTrack.LaborSetup.Services.MockProviders
{
    class MockLaborDataService : ILaborDataService
    {
        int dbSize = 100;
        List<LaborData> dataBase;

        public MockLaborDataService()
        {
            dataBase = new List<LaborData>();
            Random generator = new Random();

            for (int i=0; i<dbSize; i++)
            {
                InsertRandomLaborData(generator);
            }
        }

        public void InsertRandomLaborData(Random generator)
        {
            DateTime today = DateTime.Today.AddHours(7);
            DateTime start = today.AddMinutes(generator.Next(80));
            DateTime end = start.AddMinutes(generator.Next(800));

            dataBase.Add(new LaborData()
            {
                EmpNo = generator.Next(0, 1000000).ToString("D6"),
                EmpName = (generator.NextDouble() >= 0.5) ? "John Doe" : "Shannon Brown",
                Organization = (generator.NextDouble() >= 0.5) ? "SKYW" : "EJ",
                Type = (generator.NextDouble() >= 0.5) ? "MEAL" : "SHIFT",
                ShiftStart = start,
                ShiftEnd = end,
                ScheduleID = generator.Next(0, 1000000),
                MealID = generator.Next(0, 1000000),
                Job = (generator.NextDouble() >= 0.5) ? "MECH" : "LEAD"
            });
        }

        public List<LaborData> GetLaborData(string Base, DateTime startTime, DateTime endTime)
        {
            //assume already filtered by Base
            return dataBase.Where(l => l.ShiftStart > startTime && l.ShiftEnd < endTime).ToList();
        }
    }
}
