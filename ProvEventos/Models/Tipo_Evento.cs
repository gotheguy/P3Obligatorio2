using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProvEventos.Models
{
    [Table("Tipo_Evento")]
    public class Tipo_Evento
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
    }
}