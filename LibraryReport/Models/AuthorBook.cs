using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryReport.Models
{
    [Table("dbo.authors_books")]
    public class AuthorBook : Entity
    {
        [Column("Book_id")]
        public Book Book { get; set; }

        [Column("Author_id")]
        public Author Author { get; set; }

        public AuthorBook()
        {

        }

        public AuthorBook(Book book, Author author)
        {
            Book = book;
            Author = author;
        }
    }
}
