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
            String nombreUsuario = this.User.Identity.Name;
            if (nombreUsuario != null && nombreUsuario != "")
            {
                Usuario usu = db.Usuarios.AsEnumerable().FirstOrDefault(u => u.NombreUsuario == nombreUsuario);
                if (usu.Rol.Roles == Roles.Organizador)
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
                else
                    return View("Forbidden");
            }
            else
            {
                return View("Forbidden");
            }
        }

        [HttpPost]
        public ActionResult GetCityByStaeId(int typeId)
        {
            Tipo_Evento t = db.Tipo_Eventos.FirstOrDefault(m => m.TipoEventoID == typeId);
            List<Servicio> objServicio = new List<Servicio>();
            objServicio = db.Servicios.Where(m => m.TipoEvento.Contains(t)).ToList();
            SelectList obgServicio = new SelectList(objServicio, "Id", "CityName", 0);
            return Json(obgServicio);
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

        // POST: Evento/Create
        [HttpPost]
        public ActionResult Add(FormCollection collection)
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
