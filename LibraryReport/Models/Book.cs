using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryReport.Models
{
    [Table("dbo.books")]
    public class Book : Entity
    {
        [Column("Name")]
        public string Name { get; set; }

        [Column("Description")]
        public string Description { get; set; }

        [Column("Created_On")]
        public DateTime CreatedOn { get; set; }

        [Column("Modified_On")]
        public DateTime ModifiedOn { get; set; }

        [Column("Condition")]
        public Condition Condition { get; set; }

        [Column("Section_id")]
        public Section Section { get; set; }

        [Column("Publisher_id")]
        public Publisher Publisher { get; set; }

        public ICollection<AuthorBook> AuthorBooks { get; set; }

        public ICollection<BookClient> BookClients { get; set; }

        public Book()
        {
            CreatedOn = DateTime.Now;
            ModifiedOn = DateTime.Now;
        }

        public Book(string name, string description, Condition condition, Section section, Publisher publisher) : this()
        {
            Name = name;
            Description = description;
            Condition = condition;
            Section = section;
            Publisher = publisher;
        }
    }
}
