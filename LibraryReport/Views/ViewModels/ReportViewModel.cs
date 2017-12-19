using LibraryReport.Models;
using LibraryReport.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace LibraryReport.Views.ViewModels
{
    public class ReportViewModel : EntityViewModel
    {
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

        public DateTime CreatedOn { get; set; }

        private int countClients;
        public int CountClients
        {
            get
            {
                return countClients;
            }
            set
            {
                countClients = value;
                OnPropertyChanged(Constants.COUNT_CLIENTS);
            }
        }

        private int countSections;
        public int CountSections
        {
            get
            {
                return countSections;
            }
            set
            {
                countSections = value;
                OnPropertyChanged(Constants.COUNT_SECTIONS);
            }
        }

        private int countBooks;
        public int CountBooks
        {
            get
            {
                return countBooks;
            }
            set
            {
                countBooks = value;
                OnPropertyChanged(Constants.COUNT_BOOKS);
            }
        }

        private int countBooksInUse;
        public int CountBooksInUse
        {
            get
            {
                return countBooksInUse;
            }
            set
            {
                countBooksInUse= value;
                OnPropertyChanged(Constants.COUNT_BOOKS_IN_USE);
            }
        }

        private int countBooksNotInUse;
        public int CountBooksNotInUse
        {
            get
            {
                return countBooksNotInUse;
            }
            set
            {
                countBooksNotInUse = value;
                OnPropertyChanged(Constants.COUNT_BOOKS_NOT_IN_USE);
            }
        }

        public ReportViewModel(Report report)
        {
            Id = report.Id;
            LibraryId = report.Library.Id;
            CreatedOn = report.CreatedOn;
            CountClients = report.CountClients;
            CountSections = report.CountSections;
            CountBooks = report.CountBooks;
            CountBooksInUse = report.CountBooksInUse;
            CountBooksNotInUse = report.CountBooksNotInUse;
        }


        public static bool GetSearchPredicate(ReportViewModel model)
        {
            return model.Id.ToString().Contains(SearchPredicate.searchPredicate)
                || model.LibraryId.ToString().Contains(SearchPredicate.searchPredicate)
                || model.CreatedOn.ToString().Contains(SearchPredicate.searchPredicate)
                || model.CountClients.ToString().Contains(SearchPredicate.searchPredicate)
                || model.CountSections.ToString().Contains(SearchPredicate.searchPredicate)
                || model.CountBooks.ToString().Contains(SearchPredicate.searchPredicate)
                || model.CountBooksInUse.ToString().Contains(SearchPredicate.searchPredicate)
                || model.CountBooksNotInUse.ToString().Contains(SearchPredicate.searchPredicate);
        }

    }
}
