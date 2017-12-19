using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryReport.Models
{
    [Table("dbo.books_clients")]
    public class BookClient : BookClientBase
    {
        public BookClient()
        {
            CreatedOn = DateTime.Now;
        }

        public BookClient(Book book, Client client, DateTime untilTo): this()
        {
            Book = book;
            Client = client;
            UntilTo = untilTo;
        }
    }
}
