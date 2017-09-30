using SkyWest.Common.WPF;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyTrack.LaborSetup.AppState
{
    public class ObservableProp<T> : NotifyPropertyChangedBase
    {
        private T _value;
        public T Value
        {
            get { return _value; }
            set { _value = value; OnPropertyChanged(); }
        }
    }
}
