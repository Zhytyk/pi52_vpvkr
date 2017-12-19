using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryReport.Models
{
    [Table("dbo.books_clients_archive")]
    public class BookClientArchive : BookClientBase
    {
        public BookClientArchive()
        {
            CreatedOn = DateTime.Now;
        }

        public BookClientArchive(Book book, Client client, DateTime untilTo): this()
        {
            Book = book;
            Client = client;
            UntilTo = untilTo;
        }
    }
}
