using SkyTrack.LaborSetup.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SkyTrack.LaborSetup.Views
{
    public partial class LaborSetup : UserControl
    {
        LaborSetupViewModel ViewModel = null;
        public LaborSetup()
        {
            ViewModel = new LaborSetupViewModel();

            //DATA CONTEXT
            DataContext = ViewModel.State;

            InitializeComponent();
        }
    }
}
