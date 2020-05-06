using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MGI_Maritima.Models
{
    public class DataPrecio
    {
        public int? id { get; set; }
        public decimal precio { get; set; }
        public int? idArticulo { get; set; }

    }
}
