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

namespace LibraryReport.Views.Books
{
    /// <summary>
    /// Interaction logic for AddBook.xaml
    /// </summary>
    public partial class AddBook : Window
    {
        private IList<SectionViewModel> sectionItems;
        private IList<PublisherViewModel> publisherItems;
        private SectionViewModel selectedSectionItem;
        private PublisherViewModel selectedPublisherItem;

        public ObservableCollection<DummyComboBoxItem> SectionComboItems { get; set; }
        public ObservableCollection<DummyComboBoxItem> PublisherComboItems { get; set; }

        public AddBook()
        {
            InitializeComponent();
            DataContext = this;
        }

        public AddBook(IList<SectionViewModel> sectionItems, IList<PublisherViewModel> publisherItems) : this()
        {
            this.sectionItems = sectionItems;
            SectionComboItems = new ObservableCollection<DummyComboBoxItem>(this.sectionItems.Select(e => new DummyComboBoxItem { Id = e.Id, Value = e.Name }));
            Section.ItemsSource = SectionComboItems;

            this.publisherItems = publisherItems;
            PublisherComboItems = new ObservableCollection<DummyComboBoxItem>(this.publisherItems.Select(e => new DummyComboBoxItem { Id = e.Id, Value = e.Name }));
            Publisher.ItemsSource = PublisherComboItems;
        }

        public AddBook(IList<SectionViewModel> sectionItems, IList<PublisherViewModel> publisherItems, string name, string description, Models.Condition condition, SectionViewModel selectedSectionItem, PublisherViewModel selectedPublisherItem) : this(sectionItems, publisherItems)
        {
            Name.Text = name;
            Description.Text = description;
            Condition.Text = condition.ToString();
            this.selectedSectionItem = selectedSectionItem;
            this.selectedPublisherItem = selectedPublisherItem;
            Section.SelectedValue = selectedSectionItem.Id;
            Publisher.SelectedValue = selectedPublisherItem.Id;

            addBtn.Content = Constants.EDIT;
        }

        private void Section_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DummyComboBoxItem selectedSectionItem = Section.SelectedItem as DummyComboBoxItem;
            SectionViewModel foundSection = sectionItems.FirstOrDefault(i => i.Id == selectedSectionItem.Id);
            this.selectedSectionItem = foundSection;
        }

        private void Publisher_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DummyComboBoxItem selectedPublisherItem = Publisher.SelectedItem as DummyComboBoxItem;
            PublisherViewModel foundPublisher = publisherItems.FirstOrDefault(i => i.Id == selectedPublisherItem.Id);
            this.selectedPublisherItem = foundPublisher;
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }

        public SectionViewModel SelectedSectionItem
        {
            get
            {
                return selectedSectionItem;
            }
        }

        public PublisherViewModel SelectedPublisherItem
        {
            get
            {
                return selectedPublisherItem;
            }
        }

        public class DummyComboBoxItem
        {
            public int Id { get; set; }
            public string Value { get; set; }
        }
    }
}
