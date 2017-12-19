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
    public class SectionViewModel : EntityViewModel
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

        private int libraryId;
        public int LibraryId {
            get
            {
                return libraryId;
            }
            set
            {
                libraryId = value;
                OnPropertyChanged(Constants.LIBRARY_ID);
            }
        }

        public SectionViewModel(Section section)
        {
            Id = section.Id;
            Name = section.Name;
            Description = section.Description;
            CreatedOn = section.CreatedOn;
            ModifiedOn = section.ModifiedOn;
            LibraryId = section.Library.Id;
        }

        public static bool GetSearchPredicate(SectionViewModel model)
        {
            return model.Id.ToString().Contains(SearchPredicate.searchPredicate)
                || model.Name.Contains(SearchPredicate.searchPredicate)
                || model.Description.Contains(SearchPredicate.searchPredicate)
                || model.CreatedOn.ToString().Contains(SearchPredicate.searchPredicate)
                || model.ModifiedOn.ToString().Contains(SearchPredicate.searchPredicate)
                || model.LibraryId.ToString().Contains(SearchPredicate.searchPredicate);
        }
    }
}
