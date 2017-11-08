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
        [Required]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity), Key()]
        [Column("IdTipoEvento", Order = 1, TypeName = "int")]
        public int IdTipoEvento { get; set; }

        [Required]
        [StringLength(100)]
        [Column("NombreTipoEvento", Order = 2, TypeName = "varchar")]
        public string Nombre { get; set; }

        [StringLength(250)]
        [Column("Descripcion", Order = 3, TypeName = "varchar")]
        public string Descripcion { get; set; }

        public virtual Servicio Servicio { get; set; }
    }
}