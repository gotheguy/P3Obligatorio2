using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProvEventos.Models
{
    [Table("Proveedor_Comun")]
    public class Proveedor_Comun : Proveedor
    {
        [ForeignKey("Rut")]
        [Column("Rut", Order = 2, TypeName = "int")]
        public virtual Proveedor Proveedor { get; set; }

        public virtual Rol.Roles Rol { get; set; }
    }
}