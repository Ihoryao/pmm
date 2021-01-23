using System.Windows;
using System.Windows.Controls;
using WpfApp3.Models;
using WpfApp3.Services;

namespace WpfApp3
{
    public partial class AddSageBookWindow : Window
    {
        private readonly SageServices _sageServices = new SageServices();
        private readonly BookServices _bookServices = new BookServices();

        public AddSageBookWindow(Sage sage)
        {
            InitializeComponent();
            _sageServices.selectedSage = sage;
            ShowBooks();
        }
        
        private void BookDataGrid_OnSelected(object sender, RoutedEventArgs e)
        {
            var row = ItemsControl.ContainerFromElement((DataGrid) sender,
                e.OriginalSource as DependencyObject) as DataGridRow;
            _bookServices.selectedBook = (row as FrameworkElement).DataContext as Book;
        }

        public void SelectBookToAddButton(object s, RoutedEventArgs e)
        {
            //Book bookToAdd = (s as FrameworkElement).DataContext as Book;
            _sageServices.AddSageBook(_bookServices.selectedBook);
            Close();
        }

        private void ShowBooks()
        {
            AddSageBookDataGrid.ItemsSource = _bookServices.GetBooks();
        }
    }
}