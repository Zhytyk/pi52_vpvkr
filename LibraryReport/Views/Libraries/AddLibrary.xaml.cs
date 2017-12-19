using LibraryReport.Utils;
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
using System.Windows.Shapes;

namespace LibraryReport.Views.Libraries
{
    /// <summary>
    /// Interaction logic for Add.xaml
    /// </summary>
    public partial class AddLibrary : Window
    {
        public AddLibrary()
        {
            InitializeComponent();
        }

        public AddLibrary(string name, string description) : this()
        {
            Name.Text = name;
            Description.Text = description;

            addBtn.Content = Constants.EDIT;
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }
    }
}
