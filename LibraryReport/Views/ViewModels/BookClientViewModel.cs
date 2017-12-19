using LibraryReport.Models;
using LibraryReport.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryReport.Views.ViewModels
{
    public class BookClientViewModel : EntityViewModel
    {
        private int bookId;
        public int BookId
        {
            get
            {
                return bookId;
            }
            set
            {
                bookId = value;
                OnPropertyChanged(Constants.BOOK_ID);
            }
        }

        private int clientId;
        public int ClientId
        {
            get
            {
                return clientId;
            }
            set
            {
                clientId = value;
                OnPropertyChanged(Constants.CLIENT_ID);
            }
        }

        public DateTime CreatedOn { get; set; }


        private DateTime untilTo;
        public DateTime UntilTo
        {
            get
            {
                return untilTo;
            }
            set
            {
                untilTo = value;
                OnPropertyChanged(Constants.UNTIL_TO);
            }
        }

        public BookClientViewModel()
        {
                
        }


        public BookClientViewModel(BookClient bookClient)
        {
            Id = bookClient.Id;
            BookId = bookClient.Book.Id;
            ClientId = bookClient.Client.Id;
            CreatedOn = bookClient.CreatedOn;
            UntilTo = bookClient.UntilTo;
        }

        public static bool GetSearchPredicate(BookClientViewModel model)
        {
            return model.Id.ToString().Contains(SearchPredicate.searchPredicate)
                || model.BookId.ToString().Contains(SearchPredicate.searchPredicate)
                || model.ClientId.ToString().Contains(SearchPredicate.searchPredicate)
                || model.CreatedOn.ToString().Contains(SearchPredicate.searchPredicate)
                || model.UntilTo.ToString().Contains(SearchPredicate.searchPredicate);
        }
    }
}
