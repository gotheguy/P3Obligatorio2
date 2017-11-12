using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProvEventos.Models
{
    [Table("Rol")]
    public class Rol
    {
        public enum Roles
        {
            Administrador,
            Organizador,
            Proveedor
        }

        [Key]
        [Required]
        [Column("RolID", Order = 1, TypeName = "int")]
        public int RolID { get; set; }

        [Column("rol", Order = 2)]
        public Roles rol { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}