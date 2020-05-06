using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MGI_Maritima.Models
{
    [Table("Precio")]
    public class Precio
    {
        [Key]
        public int id { get; set; }

        public decimal precio { get; set; }

        public int?  idArticulo { get; set; }
    }
}
