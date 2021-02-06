using AntojitosWS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AntojitosWS.Controllers
{
    public class ProductosController : ApiController
    {
        [HttpGet]
        public List<ProductoModel> getProductos()
        {
            ProductoModel p = new ProductoModel();

            using (Models.AntojitosEntities db = new Models.AntojitosEntities())
            {
                return  p.efProductos(db.TEST_PRODUCTO. Where(a => a.Stock > 0).ToList());
            }
        }

    }
}
