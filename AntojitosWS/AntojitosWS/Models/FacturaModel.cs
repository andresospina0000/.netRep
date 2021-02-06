using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AntojitosWS.Models
{
    public class FacturaModel
    {
        public decimal IdFactura { get; set; }
        public decimal IdCliente { get; set; }
        public DateTime FechaVenta { get; set; }
        public decimal ValorTotal { get; set; }
        public List<FacDetalleModel> detalleProductos { get; set; }
    }
}