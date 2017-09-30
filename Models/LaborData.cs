using SkyWest.Common.WPF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyTrack.LaborSetup.Models
{
    class LaborData : NotifyPropertyChangedBase
    {
        private string _empNo;
        private string _empName;
        private string _organization;
        private string _type;
        private DateTime _shiftStart;
        private DateTime _shiftEnd;
        private double _hours;
        private int _scheduleID;
        private int _mealID;
        private string _job;

        public string EmpNo
        {
            get { return _empNo; }
            set
            {
                if (_empNo == value)
                    return;
                _empNo = value;
                OnPropertyChanged();
            }
        }

        public string EmpName
        {
            get { return _empName; }
            set
            {
                if (_empName == value)
                    return;
                _empName = value;
                OnPropertyChanged();
            }
        }

        public string Organization
        {
            get { return _organization; }
            set
            {
                if (_organization == value)
                    return;
                _organization = value;
                OnPropertyChanged();
            }
        }

        public string Type
        {
            get { return _type; }
            set
            {
                if (_type == value)
                    return;
                _type = value;
                OnPropertyChanged();
            }
        }

        public DateTime ShiftStart
        {
            get { return _shiftStart; }
            set
            {
                if (_shiftStart == value)
                    return;
                _shiftStart = value;
                OnPropertyChanged();
            }
        }

        public DateTime ShiftEnd
        {
            get { return _shiftEnd; }
            set
            {
                if (_shiftEnd == value)
                    return;
                _shiftEnd = value;
                OnPropertyChanged();
            }
        }

        public double Hours
        {
            get { return _hours; }
            set
            {
                if (_hours == value)
                    return;
                _hours = value;
                OnPropertyChanged();
            }
        }

        public int ScheduleID
        {
            get { return _scheduleID; }
            set
            {
                if (_scheduleID == value)
                    return;
                _scheduleID = value;
                OnPropertyChanged();
            }
        }

        public int MealID
        {
            get { return _mealID; }
            set
            {
                if (_mealID == value)
                    return;
                _mealID = value;
                OnPropertyChanged();
            }
        }

        public string Job
        {
            get { return _job; }
            set
            {
                if (_job == value)
                    return;
                _job = value;
                OnPropertyChanged();
            }
        }
    }
}
