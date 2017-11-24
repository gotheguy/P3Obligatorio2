using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProvEventos.Models
{
    public class EventoViewModels
    {
        [Required]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity), Key()]
        [Column("EventoID", Order = 1, TypeName = "int")]
        public int EventoID { get; set; }

        [Required]
        public virtual Tipo_Evento Tipo { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayName("Fecha de evento")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Column("FechaEvento", Order = 4, TypeName = "date")]
        public DateTime FechaEvento { get; set; }

        [Required(ErrorMessage = "Ingrese una direccion")]
        [StringLength(100, ErrorMessage = "La direccion debe tener menos de 100 caracteres")]
        [Column("Direccion", Order = 2, TypeName = "varchar")]
        public String Direccion { get; set; }

        public virtual List<Servicio> Servicios { get; set; }

        public IEnumerable<SelectListItem> TiposDeEvento { get; set; }
        //public IEnumerable<SelectListItem> ServiciosList { get; set; }
        public List<Proveedor> ProveedoresGridview { get; set; }
    }
}