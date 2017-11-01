using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProvEventos.Models
{
    [Table("Proveedor")]
    public abstract class Proveedor
    {
        public static double Arancel;

        public string Rut { get; set; }
        public string NombreFantasia { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public bool Activo { get; set; }
        public List<Servicio> Servicios { get; set; }
    }
}