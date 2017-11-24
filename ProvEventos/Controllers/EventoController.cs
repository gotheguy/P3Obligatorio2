using ProvEventos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProvEventos.Controllers
{
    public class EventoController : Controller
    {
        private ProvEventosContext db = new ProvEventosContext();
        
        // GET: Evento/Create
        public ActionResult Create()
        {
            var model = new EventoViewModels();
            var a = db.Tipo_Eventos.ToList().Select(x => x);
            model.TiposDeEvento = db.Tipo_Eventos.ToList().Select(x => new SelectListItem
            {
                Value = x.TipoEventoID.ToString(),
                Text = x.NombreTipoEvento
            });
            return View(model);
        }

        // POST: Evento/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
