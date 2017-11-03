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
        public double Porcentaje { get; set; }
    }
}