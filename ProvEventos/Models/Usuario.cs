using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProvEventos.Models
{
    [Table("Usuario")]
    public class Usuario
    {
        [Key]
        public string NombreUsuario { get; set; }

        public string Clave { get; set; }
        public DateTime FechaRegistro { get; }

        [ForeignKey("Rol")]
        public Rol Rol { get; set; }
    }
}