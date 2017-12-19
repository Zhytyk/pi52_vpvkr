using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryReport.Models
{
    [Table("dbo.clients")]
    public class Client : Entity
    {
        [Column("Name")]
        public string Name { get; set; }

        [Column("Surname")]
        public string Surname { get; set; }

        [Column("Library_id")]
        public Library Library {get;set;}

        public ICollection<BookClient> BookClients { get; set; }


        public Client()
        {

        }

        public Client(string name, string surname, Library library)
        {
            Name = name;
            Surname = surname;
            Library = library;
        }
    }
}
