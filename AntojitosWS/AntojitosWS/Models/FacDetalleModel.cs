using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AntojitosWS.Models
{
    public class FacDetalleModel
    {
        public decimal IdFacturaDetalle { get; set; }
        public decimal IdFactura { get; set; }
        public decimal IdProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal ValorUnidad { get; set; }
        public decimal ValorTotal { get; set; }
    }
}