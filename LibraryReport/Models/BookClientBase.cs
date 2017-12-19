using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryReport.Models
{
    public class BookClientBase : Entity
    {
        [Column("Book_id")]
        public virtual Book Book { get; set; }

        [Column("Client_id")]
        public virtual Client Client { get; set; }

        [Column("Created_On")]
        public virtual DateTime CreatedOn { get; set; }

        [Column("Until_To")]
        public virtual DateTime UntilTo { get; set; }
    }
}
