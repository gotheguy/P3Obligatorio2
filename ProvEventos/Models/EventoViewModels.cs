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
        public Evento Evento { get; set; }
        public IEnumerable<SelectListItem> TiposDeEvento { get; set; }
        public List<Proveedor> ProveedoresGridview { get; set; }
        public Dictionary<Servicio,Proveedor> ServiciosSeleccionados { get; set; }
    }
}