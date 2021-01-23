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
using WpfApp3.Models;
using WpfApp3.Services;

namespace WpfApp3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public SageServices _sageServices = new SageServices();
        public BookServices _bookServices = new BookServices();


        public MainWindow()
        {
            InitializeComponent();
            ShowSages();
            ShowBooks();
        }

        private void ShowSages()
        {
            SageDataGrid.ItemsSource = _sageServices.GetSages();
        }

        private void AddSageButton(object s, RoutedEventArgs e)
        {
            CreateSageWindow createSageWindow = new CreateSageWindow();
            createSageWindow.ShowDialog();
            ShowSages();
        }

        private void SelectSageToEditButton(object s, RoutedEventArgs e)
        {
            UpdateSageWindow updateSageWindow = new UpdateSageWindow(_sageServices.selectedSage);
            updateSageWindow.ShowDialog();
        }

        private void DeleteSageButton(object s, RoutedEventArgs e)
        {
            _sageServices.DeleteSage();
            ShowSages();
        }

        private void SelectSageBooks(object s, RoutedEventArgs e)
        {
            var row = ItemsControl.ContainerFromElement((DataGrid) s,
                e.OriginalSource as DependencyObject) as DataGridRow;
            _sageServices.selectedSage = (row as FrameworkElement).DataContext as Sage;
            SageBookDataGrid.ItemsSource = _sageServices.SelectSageBooks();
        }

        private void DataGridSageBook_OnSelected(object sender, RoutedEventArgs e)
        {
            var row = ItemsControl.ContainerFromElement((DataGrid) sender,
                e.OriginalSource as DependencyObject) as DataGridRow;
            _bookServices.selectedBook = (row as FrameworkElement).DataContext as Book;
        }

        private void AddSageBookButton(object s, RoutedEventArgs e)
        {
            AddSageBookWindow addSageBookWindow = new AddSageBookWindow(_sageServices.selectedSage);
            addSageBookWindow.ShowDialog();
            SageBookDataGrid.ItemsSource = _sageServices.SelectSageBooks();
        }

        private void DeleteSageBookButton(object s, RoutedEventArgs e)
        {
            _sageServices.DeleteSageBook(_bookServices.selectedBook);
            SageBookDataGrid.ItemsSource = _sageServices.SelectSageBooks();
        }

        //Books
        private void ShowBooks()
        {
            BookDataGrid.ItemsSource = _bookServices.GetBooks();
        }

        private void AddBookButton(object s, RoutedEventArgs e)
        {
            CreateBookWindow createBookWindow = new CreateBookWindow();
            createBookWindow.ShowDialog();
            ShowBooks();
        }

        private void SelectBookToEditButton(object s, RoutedEventArgs e)
        {
            UpdateBookWindow updateBookWindow = new UpdateBookWindow(_bookServices.selectedBook);
            updateBookWindow.ShowDialog();
        }

        private void DeleteBookButton(object s, RoutedEventArgs e)
        {
            _bookServices.DeleteBook();
            ShowBooks();
        }

        private void BookDataGrid_OnSelected(object sender, RoutedEventArgs e)
        {
            var row = ItemsControl.ContainerFromElement((DataGrid) sender,
                e.OriginalSource as DependencyObject) as DataGridRow;
            _bookServices.selectedBook = (row as FrameworkElement).DataContext as Book;
        }
    }
}