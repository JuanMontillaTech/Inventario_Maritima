using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MGI_Maritima.Models
{
    [Table("Almacen")]
    public class Almacen
    {
        [Key]
        public int id { get; set; }
        [Required(ErrorMessage = "Nombre del Almacen es requierido")]
        public string descripcion { get; set; }
        public string ubicacion { get; set; }
        public string Capacidad { get; set; }
     }
}
