using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryReport.Models
{
    [Table("dbo.authors")]
    public class Author : Entity
    {
        [Column("Name")]
        public string Name { get; set; }

        [Column("SurName")]
        public string SurName { get; set; }

        public ICollection<AuthorBook> AuthorBooks { get; set; }

        public Author()
        {

        }

        public Author(string name, string surname)
        {
            Name = name;
            SurName = surname;
        }
    }
}
