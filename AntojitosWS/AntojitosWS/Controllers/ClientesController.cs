using AntojitosWS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AntojitosWS.Controllers
{
    public class ClientesController : ApiController
    {

        public ClienteModel getClienteByDoc(int identificacion)
        {            
            using (Models.AntojitosEntities db = new Models.AntojitosEntities())
            {
              return new ClienteModel(db.TEST_CLIENTE.FirstOrDefault(a => a.Identifiacion.Equals(identificacion)));
            }
        }

    }
}
