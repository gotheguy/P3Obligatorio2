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
        public enum Tipo
        {
            Administrador,
            Organizador,
            Proveedor
        }

        [Key]
        //[Required]
        //[Column("id", Order = 1, TypeName = "int")]
        public int ID { get; set; }

        public Tipo tipo { get; set; }

        [Required]
        public virtual Usuario Usuario { get; set; }
    }
}