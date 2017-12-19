using LibraryReport.Models;
using LibraryReport.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryReport.Views.ViewModels
{
    public class PublisherViewModel : EntityViewModel
    {
        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                OnPropertyChanged(Constants.NAME);
            }
        }

        private string description;
        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
                OnPropertyChanged(Constants.DESCRIPTION);
            }
        }

        public PublisherViewModel(Publisher publisher)
        {
            Id = publisher.Id;
            Name = publisher.Name;
            Description = publisher.Description;
        }
        
    }
}
