using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace APICore.Models
{
    [Table("TB_M_Department")]
    public class Department
    {
        [Key]
        public int id { get; set; }
        public string Name { get; set; }

    }
}
