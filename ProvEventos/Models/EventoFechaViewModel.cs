using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProvEventos.Models
{
    public class EventoFechaViewModel
    {
        public List<Evento> Evento { get; set; }
        public DateTime Desde { get; set; }
        public DateTime Hasta { get; set; }
    }
}