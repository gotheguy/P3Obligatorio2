using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProvEventos.Models
{
    public enum Roles
    {
        Administrador,
        Organizador,
        Proveedor
    }

    [Table("Rol")]
    public class Rol
    {
        [Key]
        [Required]
        [Column("RolID", Order = 1, TypeName = "int")]
        public int RolID { get; set; }

        [Column("Rol", Order = 2)]
        public Roles? Roles { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}