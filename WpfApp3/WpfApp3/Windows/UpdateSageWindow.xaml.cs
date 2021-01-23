using System.Windows;
using WpfApp3.Models;
using WpfApp3.Services;

namespace WpfApp3
{
    public partial class UpdateSageWindow : Window
    {
        private readonly SageServices _sageServices = new SageServices();
        
        public UpdateSageWindow(Sage sage)
        {
            InitializeComponent();
            _sageServices.selectedSage = sage;
            UpdateSageGrid.DataContext = _sageServices.selectedSage;
        }

        private void UpdateSage(object s, RoutedEventArgs e)
        {
            _sageServices.UpdateSage();
            Close();
        }
    }
}