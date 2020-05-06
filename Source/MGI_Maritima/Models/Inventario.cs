using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MGI_Maritima.Models
{
    [Table("Invenatrio")]
    public class Inventario
    {
        [Key]
        public int? id { get; set; }
        public int idalmacen { get; set; }
        public int idarticulo { get; set; }
        public int cantidad { get; set; }
    }
}
