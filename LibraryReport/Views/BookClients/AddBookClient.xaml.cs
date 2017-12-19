using LibraryReport.Utils;
using LibraryReport.Views.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;

namespace LibraryReport.Views.BookClients
{
    /// <summary>
    /// Interaction logic for AddBookClient.xaml
    /// </summary>
    public partial class AddBookClient : Window
    {
        private IList<BookViewModel> bookItems;
        private IList<ClientViewModel> clientItems;
        private BookViewModel selectedBookItem;
        private ClientViewModel selectedClientItem;

        public ObservableCollection<DummyComboBoxItem> BookComboItems { get; set; }
        public ObservableCollection<DummyComboBoxItem> ClientComboItems { get; set; }

        public AddBookClient()
        {
            InitializeComponent();
            DataContext = this;
        }

        public AddBookClient(IList<BookViewModel> bookItems, IList<ClientViewModel> clientItems) : this()
        {
            this.bookItems = bookItems;
            BookComboItems = new ObservableCollection<DummyComboBoxItem>(this.bookItems.Select(e => new DummyComboBoxItem { Id = e.Id, Value = e.Name }));
            Book.ItemsSource = BookComboItems;

            this.clientItems = clientItems;
            ClientComboItems = new ObservableCollection<DummyComboBoxItem>(this.clientItems.Select(e => new DummyComboBoxItem { Id = e.Id, Value = e.Name }));
            Client.ItemsSource = ClientComboItems;
        }

        public AddBookClient(IList<BookViewModel> bookItems, IList<ClientViewModel> clientItems, DateTime untilTo, BookViewModel selectedBookItem, ClientViewModel selectedClientItem) : this(bookItems, clientItems)
        {
            this.selectedBookItem = selectedBookItem;
            this.selectedClientItem = selectedClientItem;
            UntilTo.Text = untilTo.ToString();
            Book.SelectedValue = selectedBookItem.Id;
            Client.SelectedValue = selectedClientItem.Id;

            addBtn.Content = Constants.EDIT;
        }

        private void Book_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DummyComboBoxItem selectedBookItem = Book.SelectedItem as DummyComboBoxItem;
            BookViewModel foundBook = bookItems.FirstOrDefault(i => i.Id == selectedBookItem.Id);
            this.selectedBookItem = foundBook;
        }

        private void Client_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DummyComboBoxItem selectedClientItem = Client.SelectedItem as DummyComboBoxItem;
            ClientViewModel foundClient = clientItems.FirstOrDefault(i => i.Id == selectedClientItem.Id);
            this.selectedClientItem = foundClient;
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }

        public BookViewModel SelectedBookItem
        {
            get
            {
                return selectedBookItem;
            }
        }

        public ClientViewModel SelectedClientItem
        {
            get
            {
                return selectedClientItem;
            }
        }

        public class DummyComboBoxItem
        {
            public int Id { get; set; }
            public string Value { get; set; }
        } 
    }
}
