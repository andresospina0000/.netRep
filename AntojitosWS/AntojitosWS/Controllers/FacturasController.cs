using AntojitosWS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace AntojitosWS.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*", exposedHeaders: "X-Custom-Header")]
    public class FacturasController : ApiController
    {
        [HttpPost]
        public int registrarVenta(FacturaModel factura)
        {
            using (Models.AntojitosEntities db = new AntojitosEntities())
            {
                db.TEST_FACTURA.Add(new TEST_FACTURA(factura));
                db.SaveChanges();
                registrarFactDetalle(factura);                
            }
            return 0;
        }

        private void registrarFactDetalle(FacturaModel factura)
        {
            using (Models.AntojitosEntities db = new AntojitosEntities())
            {
                foreach(FacDetalleModel p in factura.detalleProductos)
                {
                    db.TEST_FACTURA_DETALLE.Add(new TEST_FACTURA_DETALLE(p));
                    db.SaveChanges();
                    updateStock(p);
                }
            }
        }

        [HttpGet]
        public Decimal getConsecutivo()
        {
            Decimal conse = 0;
            using (Models.AntojitosEntities db = new AntojitosEntities())
            {
                int facturas = db.TEST_FACTURA.Count();

                if (facturas > 0)
                    conse = db.TEST_FACTURA.Max(a => a.IdFactura + 1);
                else
                    conse = 1;
            }
            return conse;
        }

        private void updateStock(FacDetalleModel p)
        {
            using (Models.AntojitosEntities db = new AntojitosEntities())
            {
                Models.TEST_PRODUCTO upProducto = db.TEST_PRODUCTO.First(a => a.IdProducto.Equals(p.IdProducto));
                upProducto.Stock = upProducto.Stock - p.Cantidad;
                db.SaveChanges();
            }
        }
    }
}
