using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MGI_Maritima.Models
{
    [Table("Articulo")]
    public class Articulo
    {
        [Key]
        public int id { get; set; }
        [Required(ErrorMessage = "Nombre del articulo es requierido")]
        [Display(Name = "Articulo")]
        public string nombre { get; set; }

        public string Descripcion { get; set; }
      

    }
}
