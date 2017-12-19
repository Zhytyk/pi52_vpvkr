using LibraryReport.Models;
using LibraryReport.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryReport.Views.ViewModels
{
    public class AuthorViewModel : EntityViewModel
    {
        private string name;
        public string Name {
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

        private string surname;
        public string SurName {
            get
            {
                return surname;
            }
            set
            {
                surname = value;
                OnPropertyChanged(Constants.SURNAME);
            }
        }

        public AuthorViewModel(Author author)
        {
            Id = author.Id;
            Name = author.Name;
            SurName = author.SurName;
        }

        public static bool GetSearchPredicate(AuthorViewModel model)
        {
            return model.Id.ToString().Contains(SearchPredicate.searchPredicate)
                || model.Name.Contains(SearchPredicate.searchPredicate)
                || model.SurName.Contains(SearchPredicate.searchPredicate);
        }
    }
}
