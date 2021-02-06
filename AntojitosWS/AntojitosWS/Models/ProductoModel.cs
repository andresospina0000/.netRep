using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AntojitosWS.Models
{
    public class ProductoModel
    {
        public Decimal id { get; set; }
        public string codigo { get; set; }
        public string nombre { get; set; }
        public Decimal valor { get; set; }
        public int stock { get; set; }
        public int cantVendidos { get; set; }

        public ProductoModel() { }

        public ProductoModel(Models.TEST_PRODUCTO efProducto)
        {
            this.id = efProducto.IdProducto;
            this.codigo = efProducto.Codigo;
            this.nombre = efProducto.Nombre;
            this.valor = efProducto.ValorUnidad;
            this.stock = efProducto.Stock;
        }

        public ProductoModel(FacDetalleModel efProducto)
        {
            this.id = efProducto.IdProducto;
            this.stock = efProducto.Cantidad;
        }

        public List<ProductoModel> efProductos(List<Models.TEST_PRODUCTO> efProductos)
        {
            List<ProductoModel> lstProductos = new List<ProductoModel>();

            for (int i = 0; i < efProductos.Count; i++)
            {
                ProductoModel producto = new ProductoModel(efProductos.ElementAt(i));
                lstProductos.Add(producto);
            }

            return lstProductos;
        }

    }

}
