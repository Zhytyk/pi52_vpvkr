using LibraryReport.Models;
using LibraryReport.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryReport.Views.ViewModels
{
    public class BookClientArchiveViewModel : BookClientViewModel
    {
        public BookClientArchiveViewModel()
        {

        }

        public BookClientArchiveViewModel(BookClientArchive bookClientArchive)
        {

            Id = bookClientArchive.Id;
            BookId = bookClientArchive.Book.Id;
            ClientId = bookClientArchive.Client.Id;
            CreatedOn = bookClientArchive.CreatedOn;
            UntilTo = bookClientArchive.UntilTo;
        }

        public static bool GetSearchPredicate(BookClientArchiveViewModel model)
        {
            return model.Id.ToString().Contains(SearchPredicate.searchPredicate)
                || model.BookId.ToString().Contains(SearchPredicate.searchPredicate)
                || model.ClientId.ToString().Contains(SearchPredicate.searchPredicate)
                || model.CreatedOn.ToString().Contains(SearchPredicate.searchPredicate)
                || model.UntilTo.ToString().Contains(SearchPredicate.searchPredicate);
        }
    }
}
