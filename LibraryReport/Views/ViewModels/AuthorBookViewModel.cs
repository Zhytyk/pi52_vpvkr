using LibraryReport.Models;
using LibraryReport.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryReport.Views.ViewModels
{
    public class AuthorBookViewModel : EntityViewModel
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

        private int authorId;
        public int AuthorId
        {
            get
            {
                return authorId;
            }
            set
            {
                authorId = value; 
                OnPropertyChanged(Constants.AUTHOR_ID);
            }
        }


        public AuthorBookViewModel(AuthorBook authorBook)
        {
            Id = authorBook.Id;
            BookId = authorBook.Book.Id;
            AuthorId = authorBook.Author.Id;
        }

        public static bool GetSearchPredicate(AuthorBookViewModel model)
        {
            return model.Id.ToString().Contains(SearchPredicate.searchPredicate)
                || model.BookId.ToString().Contains(SearchPredicate.searchPredicate)
                || model.AuthorId.ToString().Contains(SearchPredicate.searchPredicate);
        }
    }
}
