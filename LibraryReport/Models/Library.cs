using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryReport.Models
{
    [Table("dbo.libraries")]
    public class Library : Entity
    {
        [Column("Name")]
        public string Name { get; set; }

        [Column("Description")]
        public string Description { get; set; }

        [Column("Created_on")]
        public DateTime CreatedOn { get; set; }

        [Column("Modified_on")]
        public DateTime ModifiedOn { get; set; }

        public virtual ICollection<Section> Sections { get; set; }

        public virtual ICollection<Client> Clients { get; set; }

        public Library()
        {
            CreatedOn = DateTime.Now;
            ModifiedOn = DateTime.Now;
        }

        public Library(string name, string description) : this()
        {
            Name = name;
            Description = description;
        }
    }
}
