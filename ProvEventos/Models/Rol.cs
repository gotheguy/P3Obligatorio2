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
        [Key]
        [Required]
        [Column("idrol", Order = 1, TypeName = "integer")]
        public int ID { get; set; }

        public enum Roles
        {
            Proveedor,
            Administrador,
            Organizador
        }
    }
}