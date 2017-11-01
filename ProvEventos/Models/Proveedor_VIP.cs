using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProvEventos.Models
{
    public class Proveedor_VIP : Proveedor
    {
        public double Porcentaje { get; set; }
    }
}