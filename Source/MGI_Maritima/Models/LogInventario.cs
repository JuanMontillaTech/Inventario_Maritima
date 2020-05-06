using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MGI_Maritima.Models
{
    [Table("Loginvenatario")]
    public class LogInventario
    {
        [Key]
        public int id { get; set; }
        public int idubicacion { get; set; }
        public int idarticulo { get; set; }
        public string detalle { get; set; }
        public DateTime fecha { get; set; }

    }
}
