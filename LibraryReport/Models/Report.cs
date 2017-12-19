using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryReport.Models
{
    [Table("dbo.reports")]
    public class Report : Entity
    {
        [Column("Library_id")]
        public Library Library { get; set; }

        [Column("Created_On")]
        public DateTime CreatedOn { get; set; }

        [Column("Count_clients")]
        public int CountClients { get; set; }

        [Column("Count_sections")]
        public int CountSections { get; set; }

        [Column("Count_books")]
        public int CountBooks { get; set; }

        [Column("Count_books_inuse")]
        public int CountBooksInUse { get; set; }

        [Column("Count_books_notinuse")]
        public int CountBooksNotInUse { get; set; }

        public Report()
        {
            CreatedOn = DateTime.Now;
        }

        public Report(Library library) : this()
        {
            Library = library;
        }
    }
}
