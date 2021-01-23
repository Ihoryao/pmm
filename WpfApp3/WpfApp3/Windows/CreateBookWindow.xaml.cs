using System.Windows;
using WpfApp3.Services;

namespace WpfApp3
{
    public partial class CreateBookWindow : Window
    {
        private readonly BookServices _bookServices = new BookServices();

        public CreateBookWindow()
        {
            InitializeComponent();
            NewBookGrid.DataContext = _bookServices.newBook;
        }

        private void AddBookButton(object s, RoutedEventArgs e)
        {
            _bookServices.AddBook();
            Close();
        }
    }
}