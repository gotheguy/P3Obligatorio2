using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace ProvEventos.Models
{
    [Table("Tipo_Evento")]
    public class Tipo_Evento
    {
        [Required]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity), Key()]
        [Column("TipoEventoID", Order = 1, TypeName = "int")]
        public int TipoEventoID { get; set; }

        [Required]
        [DisplayName("Evento")]
        [StringLength(100, ErrorMessage = "El nombre no puede ser mayor a 100 caracteres")]
        [Column("NombreTipoEvento", Order = 2, TypeName = "varchar")]
        public string NombreTipoEvento { get; set; }

        [StringLength(250, ErrorMessage = "El nombre no puede ser mayor a 250 caracteres")]
        [Column("Descripcion", Order = 3, TypeName = "varchar")]
        public string Descripcion { get; set; }

        public virtual ICollection<Servicio> Servicios { get; set; }

        public virtual ICollection<Evento> Eventos { get; set; }
    }
}