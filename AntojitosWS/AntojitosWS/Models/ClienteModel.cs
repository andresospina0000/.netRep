using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AntojitosWS.Models
{
    public class ClienteModel
    {
        public decimal IdCliente { get; set; }
        public decimal Identifiacion { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }

        public ClienteModel() { }

        public ClienteModel(Models.TEST_CLIENTE efCliente)
        {
            this.IdCliente = efCliente.IdCliente;
            this.Identifiacion = efCliente.Identifiacion;
            this.Nombres = efCliente.Nombres;
            this.Apellidos = efCliente.Apellidos;
            this.Direccion = efCliente.Direccion;
            this.Telefono = efCliente.Telefono;
            this.Email = efCliente.Email;
        }

        public List<ClienteModel> efClientes(List<Models.TEST_CLIENTE> efClientes)
        {
            List<ClienteModel> lstProductos = new List<ClienteModel>();

            for (int i = 0; i < efClientes.Count; i++)
            {
                ClienteModel producto = new ClienteModel(efClientes.ElementAt(i));
                lstProductos.Add(producto);
            }

            return lstProductos;
        }

    }

}
