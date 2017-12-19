using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryReport.Models
{
    [Table("dbo.publishers")]
    public class Publisher : Entity
    {
        [Column("Name")]
        public string Name { get; set; }

        [Column("Description")]
        public string Description { get; set; }


        public ICollection<Book> Books { get; set; }

        public Publisher()
        {

        }

        public Publisher(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
