using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProvEventos.Models
{
    public class ServicioProveedor
    {
        public int IdServicio { get; set; }
        public string NombreServicio { get; set; }
        public string IdProveedor { get; set; }
        public string NombreProveedor { get; set; }
    }
}