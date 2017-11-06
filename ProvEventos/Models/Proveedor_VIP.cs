using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProvEventos.Models
{
    [Table("Proveedor_VIP")]
    public class Proveedor_VIP : Proveedor
    {
        [Range(0.00, 100.00, ErrorMessage = "El porcentaje debe ser entre 0.00 y 100.00")]
        [Column("Porcentaje", Order = 2)]
        public double Porcentaje { get; set; }

        public virtual Proveedor Proveedor { get; set; }
    }
}