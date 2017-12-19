using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryReport.Models
{
    [Table("dbo.sections")]
    public class Section : Entity
    {
        [Column("Name")]
        public string Name { get; set; }

        [Column("Description")]
        public string Description { get; set; }

        [Column("Created_on")]
        public DateTime CreatedOn { get; set; }

        [Column("Modified_on")]
        public DateTime ModifiedOn { get; set; }

        [Column("Library_Id")]
        public Library Library { get; set; }

        public Section()
        {
            CreatedOn = DateTime.Now;
            ModifiedOn = DateTime.Now;
        }

        public Section(string name, string description, Library library) : this()
        {
            Name = name;
            Description = description;
            Library = library;
        }
    }
}
