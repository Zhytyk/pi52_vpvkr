using LibraryReport.Models;
using LibraryReport.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryReport.Views.ViewModels
{
    public class BookViewModel : EntityViewModel
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

        private Condition condition;
        public Condition Condition
        {
            get
            {
                return condition;
            }
            set
            {
                condition = value;
                OnPropertyChanged(Constants.CONDITION);
            }
        }

        private int sectionId;
        public int SectionId
        {
            get
            {
                return sectionId;
            }
            set
            {
                sectionId = value;
                OnPropertyChanged(Constants.SECTION_ID);
            }
        }

        private int publisherId;
        public int PublisherId
        {
            get
            {
                return publisherId;
            }
            set
            {
                publisherId = value;
                OnPropertyChanged(Constants.PUBLISHER_ID);
            }
        }


        public BookViewModel(Book book)
        {
            Id = book.Id;
            Name = book.Name;
            Description = book.Description;
            CreatedOn = book.CreatedOn;
            ModifiedOn = book.ModifiedOn;
            SectionId = book.Section.Id;
            PublisherId = book.Publisher.Id;
        }

        public static bool GetSearchPredicate(BookViewModel model)
        {
            return model.Id.ToString().Contains(SearchPredicate.searchPredicate)
                || model.Name.Contains(SearchPredicate.searchPredicate)
                || model.Description.Contains(SearchPredicate.searchPredicate)
                || model.CreatedOn.ToString().Contains(SearchPredicate.searchPredicate)
                || model.ModifiedOn.ToString().Contains(SearchPredicate.searchPredicate)
                || model.SectionId.ToString().Contains(SearchPredicate.searchPredicate)
                || model.PublisherId.ToString().Contains(SearchPredicate.searchPredicate);
        }
    }
}
