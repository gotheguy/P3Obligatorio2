using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProvEventos.Models
{
    [Table("Administrador")]
    public class Administrador : Usuario
    {
        [ForeignKey("IdUsuario")]
        [Column("IdUsuario", Order = 2, TypeName = "int")]
        public virtual Usuario Usuario { get; set; }
    }
}