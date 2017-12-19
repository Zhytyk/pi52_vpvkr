using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryReport.Models
{
    public class Entity
    {
        [Key]
        [Column("Id")]
        public virtual int Id { get; set; }
    }
}
