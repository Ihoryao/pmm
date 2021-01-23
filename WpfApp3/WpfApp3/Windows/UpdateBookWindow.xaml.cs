using System.Windows;
using WpfApp3.Models;
using WpfApp3.Services;

namespace WpfApp3
{
    public partial class UpdateBookWindow : Window
    {
        private readonly BookServices _bookServices = new BookServices();

        public UpdateBookWindow(Book book)
        {
            InitializeComponent();
            _bookServices.selectedBook = book;
            UpdateBookGrid.DataContext = _bookServices.selectedBook;
        }

        private void UpdateBookButton(object s, RoutedEventArgs e)
        {
            _bookServices.UpdateBook();
            Close();
        }
    }
}