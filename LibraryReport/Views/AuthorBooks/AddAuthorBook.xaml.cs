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

namespace LibraryReport.Views.AuthorBooks
{
    /// <summary>
    /// Interaction logic for AddAuthorBook.xaml
    /// </summary>
    public partial class AddAuthorBook : Window
    {
        private IList<BookViewModel> bookItems;
        private IList<AuthorViewModel> authorItems;
        private BookViewModel selectedBookItem;
        private AuthorViewModel selectedAuthorItem;

        public ObservableCollection<DummyComboBoxItem> BookComboItems { get; set; }
        public ObservableCollection<DummyComboBoxItem> AuthorComboItems { get; set; }

        public AddAuthorBook()
        {
            InitializeComponent();
            DataContext = this;
        }

        public AddAuthorBook(IList<BookViewModel> bookItems, IList<AuthorViewModel> authorItems) : this()
        {
            this.bookItems = bookItems;
            BookComboItems = new ObservableCollection<DummyComboBoxItem>(this.bookItems.Select(e => new DummyComboBoxItem { Id = e.Id, Value = e.Name }));
            Book.ItemsSource = BookComboItems;

            this.authorItems = authorItems;
            AuthorComboItems = new ObservableCollection<DummyComboBoxItem>(this.authorItems.Select(e => new DummyComboBoxItem { Id = e.Id, Value = e.Name }));
            Author.ItemsSource = AuthorComboItems;
        }

        public AddAuthorBook(IList<BookViewModel> bookItems, IList<AuthorViewModel> authorItems, BookViewModel selectedBookItem, AuthorViewModel selectedAuthorItem) : this(bookItems, authorItems)
        {
            this.selectedBookItem = selectedBookItem;
            this.selectedAuthorItem = selectedAuthorItem;
            Book.SelectedValue = selectedBookItem.Id;
            Author.SelectedValue = selectedAuthorItem.Id;

            addBtn.Content = Constants.EDIT;
        }

        private void Book_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DummyComboBoxItem selectedBookItem = Book.SelectedItem as DummyComboBoxItem;
            BookViewModel foundBook = bookItems.FirstOrDefault(i => i.Id == selectedBookItem.Id);
            this.selectedBookItem = foundBook;
        }

        private void Author_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DummyComboBoxItem selectedAuthorItem = Author.SelectedItem as DummyComboBoxItem;
            AuthorViewModel foundAuthor = authorItems.FirstOrDefault(i => i.Id == selectedAuthorItem.Id);
            this.selectedAuthorItem = foundAuthor;
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

        public AuthorViewModel SelectedAuthorItem
        {
            get
            {
                return selectedAuthorItem;
            }
        }

        public class DummyComboBoxItem
        {
            public int Id { get; set; }
            public string Value { get; set; }
        }
    }
}
