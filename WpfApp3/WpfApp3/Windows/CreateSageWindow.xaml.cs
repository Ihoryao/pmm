using System.Windows;
using WpfApp3.Models;
using WpfApp3.Services;

namespace WpfApp3
{
    public partial class CreateSageWindow : Window
    {
        private readonly SageServices _sageServices = new SageServices();

        public CreateSageWindow()
        {
            InitializeComponent();
            NewSageGrid.DataContext = _sageServices.newSage;
        }

        private void AddSage(object s, RoutedEventArgs e)
        {
            _sageServices.AddSage();
            Close();
        }
    }
}