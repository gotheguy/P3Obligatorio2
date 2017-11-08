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
        [Column("IdRol", Order = 1, TypeName = "int")]
        public int IdRol { get; set; }

        //[Column("Tipo", Order = 2)]
        public Roles rol { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}