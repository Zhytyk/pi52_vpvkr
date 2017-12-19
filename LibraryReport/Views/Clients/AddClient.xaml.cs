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

namespace LibraryReport.Views.Clients
{
    /// <summary>
    /// Interaction logic for AddClient.xaml
    /// </summary>
    public partial class AddClient : Window
    {
        private IList<LibraryViewModel> libraryItems;
        private LibraryViewModel selectedItem;

        public ObservableCollection<DummyComboBoxItem> ComboItems { get; set; }

        public AddClient()
        {
            InitializeComponent();
            DataContext = this;
        }

        public AddClient(IList<LibraryViewModel> libraryItems) : this()
        {
            this.libraryItems = libraryItems;
            ComboItems = new ObservableCollection<DummyComboBoxItem>(this.libraryItems.Select(e => new DummyComboBoxItem { Id = e.Id, Value = e.Name }));
            Library.ItemsSource = ComboItems;
        }

        public AddClient(IList<LibraryViewModel> librayItems, string name, string surname
            ,LibraryViewModel selectedItem) : this(librayItems)
        {
            Name.Text = name;
            Surname.Text = surname;
            this.selectedItem = selectedItem;
            Library.SelectedValue = selectedItem.Id;

            addBtn.Content = Constants.EDIT;
        }

        private void Library_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DummyComboBoxItem selectedItem = Library.SelectedItem as DummyComboBoxItem;

            LibraryViewModel foundLibrary = libraryItems.FirstOrDefault(i => i.Id == selectedItem.Id);

            this.selectedItem = foundLibrary;
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }

        public LibraryViewModel SelectedItem
        {
            get
            {
                return selectedItem;
            }
        }

        public class DummyComboBoxItem
        {
            public int Id { get; set; }
            public string Value { get; set; }
        }
    }
}
