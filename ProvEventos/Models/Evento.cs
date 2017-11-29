using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProvEventos.Models
{
    [Table("Evento")]
    public class Evento
    {
        [Required]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity), Key()]
        [Column("EventoID", Order = 1, TypeName = "int")]
        public int EventoID { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayName("Fecha de evento")]
        [DisplayFormat(DataFormatString = "{0: dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Column("FechaEvento", Order = 3, TypeName = "date")]
        public DateTime FechaEvento { get; set; }

        [Required(ErrorMessage = "Ingrese una direccion")]
        [DisplayName("Dirección")]
        [StringLength(100, ErrorMessage = "La direccion debe tener menos de 100 caracteres")]
        [Column("Direccion", Order = 2, TypeName = "varchar")]
        public String Direccion { get; set; }

        public int TipoEventoID { get; set; }
        public virtual Tipo_Evento TipoEvento { get; set; }

        public virtual List<Servicio> Servicios { get; set; }

        public virtual List<Proveedor> Proveedores { get; set; }

        public virtual Organizador Organizador { get; set; }
    }
}