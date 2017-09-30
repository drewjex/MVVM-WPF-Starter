using SkyWest.Common.WPF;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyTrack.LaborSetup.Models
{
    class SetupData : NotifyPropertyChangedBase
    {
        private List<string> _bases;
        private List<string> _times;
        private DateTime _selectedDate;

        public List<string> Bases
        {
            get { return _bases; }
            set
            {
                if (_bases == value)
                    return;
                _bases = value;
                OnPropertyChanged();
            }
        }

        public List<string> Times
        {
            get { return _times; }
            set
            {
                if (_times == value)
                    return;
                _times = value;
                OnPropertyChanged();
            }
        }

        public DateTime SelectedDate
        {
            get { return _selectedDate; }
            set
            {
                if (_selectedDate == value)
                    return;
                _selectedDate = value;
                OnPropertyChanged();
            }
        }
    }
}
