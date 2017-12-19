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
    public class LibraryViewModel : EntityViewModel
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

        public DateTime CreatedOn { get; set; }

        private DateTime modifiedOn;
        public DateTime ModifiedOn
        {
            get
            {
                return modifiedOn;
            }
            set
            {
                modifiedOn = value;
                OnPropertyChanged(Constants.MODIFIED_ON);
            }
        }

        public LibraryViewModel(Library library)
        {
            Id = library.Id;
            Name = library.Name;
            Description = library.Description;
            CreatedOn = library.CreatedOn;
            ModifiedOn = library.ModifiedOn;
        }

        public static bool GetSearchPredicate(LibraryViewModel model)
        {
            return model.Id.ToString().Contains(SearchPredicate.searchPredicate)
                || model.Name.Contains(SearchPredicate.searchPredicate)
                || model.Description.Contains(SearchPredicate.searchPredicate)
                || model.CreatedOn.ToString().Contains(SearchPredicate.searchPredicate)
                || model.ModifiedOn.ToString().Contains(SearchPredicate.searchPredicate);
        }
    }
}
