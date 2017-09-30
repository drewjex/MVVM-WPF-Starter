using SkyTrack.Annotations;
using SkyTrack.LaborSetup.Models;
using SkyWest.Common.WPF;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SkyTrack.LaborSetup.AppState
{
    class State : INotifyPropertyChanged
    {
        private string _selectedBase;
        private DateTime _selectedDate;
        private DateTime _selectedStartTime;
        private DateTime _selectedEndTime;
        private TrulyObservableCollection<LaborData> _laborDataCollection;

        private ObservableCollection<string> _bases;
        private ObservableCollection<DateTime> _times;

        public Dictionary<string, Action> EventHandlers;

        public State(Dictionary<string, Action> eventHandlers)
        {
            EventHandlers = eventHandlers;
            _laborDataCollection = new TrulyObservableCollection<LaborData>();
            _bases = new ObservableCollection<string>();
            _times = new ObservableCollection<DateTime>();
        }

        public TrulyObservableCollection<LaborData> LaborDataCollection
        {
            get { return _laborDataCollection; }
            set
            {
                if (_laborDataCollection == value)
                    return;
                _laborDataCollection = value;
                OnPropertyChanged();
            }
        }

        public string SelectedBase
        {
            get { return _selectedBase; }
            set
            {
                if (_selectedBase == value)
                    return;
                _selectedBase = value;
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

        public DateTime SelectedStartTime
        {
            get { return _selectedStartTime; }
            set
            {
                if (_selectedStartTime == value)
                    return;
                _selectedStartTime = value;
                OnPropertyChanged();
            }
        }

        public DateTime SelectedEndTime
        {
            get { return _selectedEndTime; }
            set
            {
                if (_selectedEndTime == value)
                    return;
                _selectedEndTime = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<string> Bases
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

        public ObservableCollection<DateTime> Times
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

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged(Action Handler = null, [CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));

            if (EventHandlers.ContainsKey(propertyName))  {
                EventHandlers[propertyName]();
            }
        }
    }
}
