using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProvEventos.Models;
using System.Globalization;

namespace ProvEventos.Controllers
{
    public class ListaEventosxFechaController : Controller
    {
        private ProvEventosContext db = new ProvEventosContext();

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Eventos()
        {
            String nombreUsuario = this.User.Identity.Name;
            if (nombreUsuario != null && nombreUsuario != "")
            {
                Usuario usu = db.Usuarios.AsEnumerable().FirstOrDefault(u => u.UserName == nombreUsuario);
                if (usu.Rol.Roles == Roles.Administrador)
                {
                    var eventos = from p in db.Eventos
                                  select p;

                    return View(eventos);
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
        public ActionResult Eventos(string fechaini, string fechafin)
        {
            string nombreUsuario = this.User.Identity.Name;
            if (nombreUsuario != null && nombreUsuario != "")
            {
                Usuario usu = db.Usuarios.AsEnumerable().FirstOrDefault(u => u.UserName == nombreUsuario);
                if (usu.Rol.Roles == Roles.Administrador)
                {
                    var eventos = default(object);

                    DateTime dI;
                    DateTime dF;
                    bool tryParseDI = DateTime.TryParse(fechaini, out dI);
                    bool tryParseDF = DateTime.TryParse(fechafin, out dF);
                    if (!tryParseDI && !tryParseDF)
                    {
                        eventos = from p in db.Eventos
                                  select p;
                    }
                    else if (tryParseDI && !tryParseDF)
                    {
                        eventos = from p in db.Eventos
                                  where p.FechaEvento >= dI
                                  select p;
                    }
                    else if (tryParseDI && tryParseDF)
                    {
                        eventos = from p in db.Eventos
                                  where p.FechaEvento >= dI && p.FechaEvento <= dF
                                  select p;
                    }
                    else if (!tryParseDI && tryParseDF)
                    {
                        eventos = from p in db.Eventos
                                  where p.FechaEvento <= dF
                                  select p;
                    }
                    return View(eventos);
                }
                else
                    return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}
