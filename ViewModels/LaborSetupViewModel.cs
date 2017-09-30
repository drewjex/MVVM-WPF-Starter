using SkyTrack.LaborSetup.AppState;
using SkyTrack.LaborSetup.Models;
using SkyTrack.LaborSetup.Repositories;
using SkyWest.Common;
using SkyWest.Common.WPF;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SkyTrack.LaborSetup.ViewModels
{
    class LaborSetupViewModel : ViewModelBase
    {
        public LaborSetupRepository Repo = null;
        public State State = null;

        public ICommand AddCommand { get; private set; }
        public ICommand ModifyCommand { get; private set; }
        public ICommand DeleteCommand { get; private set; }

        public bool useMockData = true;

        public LaborSetupViewModel()
        {
            //REPO
            Repo = new LaborSetupRepository(useMockData);

            //EVENT HANDLERS
            Dictionary<string, Action> handlers = new Dictionary<string, Action>();
            handlers.Add("SelectedBase", Settings_PropertyChanged);
            handlers.Add("SelectedDate", Settings_PropertyChanged);
            handlers.Add("SelectedStartTime", Settings_PropertyChanged);
            handlers.Add("SelectedEndTime", Settings_PropertyChanged);

            AddCommand = new RelayCommand(AddCommand_Handler);
            ModifyCommand = new RelayCommand(ModifyCommand_Handler);
            DeleteCommand = new RelayCommand(DeleteCommand_Handler);

            //STATE
            State = new State(handlers);

            Init();
        }

        public void Init()
        {
            Do_GetBases();
            Do_GetTimes();

            State.SelectedDate = DateTime.Now;
            State.SelectedStartTime = DateTime.Parse("08:00");
            State.SelectedEndTime = DateTime.Parse("17:00");
        }

        #region Handlers

        //Combine add and modify buttons
        //bind grid to "unvalidated" observable collection which, when "save" button is selected, simply checks
        //that all the data is valid, and if so, replaces the REAL observable collection with the unvalidated (though
        //not it's validated collection)
        //question: add one row at a time or multiple?? if only one, we'd somehow have to prevent being able to continue adding rows...

        private void AddCommand_Handler()
        {
            if (CanDo_AddNewRow())
                Do_AddNewRow();
            else
                ErrorMessage("Cannot add row. Invalid data provided."); //possibly even get data from CanDo method
        }

        private void ModifyCommand_Handler()
        {

        }

        private void DeleteCommand_Handler()
        {

        }

        private void Settings_PropertyChanged()
        {
            if (CanDo_LoadFilteredData())
                Do_LoadFilteredData();
            else
                Do_UnloadFilteredData();  
        }

        private void LaborData_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            //if (e.PropertyName == "EmpNo")
            //    Console.WriteLine("EmpNo");
        }

        #endregion Handlers

        #region CanDo

        private bool CanDo_LoadFilteredData()
        {
            if (State.SelectedBase == null || State.SelectedBase == "Select a Base")
                return false;

            if (State.SelectedDate == null)
                return false;

            if (State.SelectedStartTime == null || State.SelectedStartTime == DateTime.MinValue)
                return false;

            if (State.SelectedEndTime == null || State.SelectedEndTime == DateTime.MinValue)
                return false;

            return true;
        }

        private bool CanDo_AddNewRow()
        {
            return true;
        }

        #endregion  CanDo

        #region Methods
        public void Do_GetBases()
        {
            State.Bases = new ObservableCollection<string>(Repo.GetBases());
        }

        public void Do_GetTimes()
        {
            State.Times = new ObservableCollection<DateTime>(Repo.GetTimes());
        }

        public void Do_LoadFilteredData()
        {
            if (State.SelectedEndTime < State.SelectedStartTime) //if end time is before start time, it means it's an overnight shift, so add one day to endtime
                State.SelectedEndTime.AddDays(1);
            State.LaborDataCollection = new TrulyObservableCollection<LaborData>(Repo.GetLaborData(State.SelectedBase, State.SelectedStartTime, State.SelectedEndTime), LaborData_PropertyChanged);
            Do_CalculateHours();
        }

        public void Do_UnloadFilteredData()
        {
            State.LaborDataCollection = new TrulyObservableCollection<LaborData>();
        }

        public void Do_CalculateHours()
        {
            foreach (LaborData data in State.LaborDataCollection) //automatically calculate for hours
            {
                data.Hours = Math.Round((data.ShiftEnd - data.ShiftStart).TotalHours, 2);
            }
        }

        public void Do_AddNewRow()
        {

        }

        public void Do_GetTargetCapacity(string Base, DateTime selectedDate)
        {

        }

        public void Do_AddLaborData(string Base, DateTime selectedDate)
        {

        }

        public void Do_ModifyLaborData()
        {

        }

        public void Do_DeleteLaborData()
        {

        }

        public void ErrorMessage(string message)
        {
            //display error message with message
        }

        #endregion Methods
    }
}
