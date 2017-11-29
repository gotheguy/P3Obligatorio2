using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProvEventos.Models
{
    public class ServicioProveedor
    {
        public Servicio Servicio { get; set; }
        public Proveedor Proveedor { get; set; }
    }
}