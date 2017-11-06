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
        [Key]
        //[Required]
        //[Column("id", Order = 1, TypeName = "int")]
        public int ID { get; set; }

        //[Required]
        //[StringLength(100)]
        //[Column("nombre", Order = 2, TypeName = "varchar")]
        public string Nombre { get; set; }

        //[StringLength(250)]
        //[Column("descripcion", Order = 3, TypeName = "varchar")]
        public string Descripcion { get; set; }

        public virtual Servicio Servicio { get; set; }
    }
}