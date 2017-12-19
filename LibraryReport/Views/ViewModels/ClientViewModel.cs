using LibraryReport.Models;
using LibraryReport.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryReport.Views.ViewModels
{
    public class ClientViewModel : EntityViewModel
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

        private int libraryId;
        public int LibraryId
        {
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

        public ClientViewModel(Client client)
        {
            Id = client.Id;
            Name = client.Name;
            SurName = client.Surname;
            LibraryId = client.Library.Id;
        }

        public static bool GetSearchPredicate(ClientViewModel model)
        {
            return model.Id.ToString().Contains(SearchPredicate.searchPredicate)
                || model.Name.Contains(SearchPredicate.searchPredicate)
                || model.SurName.Contains(SearchPredicate.searchPredicate)
                || model.LibraryId.ToString().Contains(SearchPredicate.searchPredicate);
        }
    }
}
