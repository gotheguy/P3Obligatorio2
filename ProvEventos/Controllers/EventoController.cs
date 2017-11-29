﻿using ProvEventos.Models;
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

        private EventoViewModels model = new EventoViewModels();

        // GET: Evento/Create
        public ActionResult Create()
        {
            String nombreUsuario = this.User.Identity.Name;
            if (nombreUsuario != null && nombreUsuario != "")
            {
                Usuario usu = db.Usuarios.AsEnumerable().FirstOrDefault(u => u.UserName == nombreUsuario);
                if (usu.Rol.Roles == Roles.Organizador)
                {
                    //var model = new EventoViewModels();
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

        [HttpGet]
        public ActionResult GetServiceData(int? typeId)
        {
            SelectList obgServicio = new SelectList("");
            if (typeId != null)
            {
                Tipo_Evento t = db.Tipo_Eventos.FirstOrDefault(m => m.TipoEventoID == typeId);
                if (t != null)
                {
                    List<Servicio> objServicio = new List<Servicio>();
                    objServicio = t.Servicios.ToList<Servicio>();
                    obgServicio = new SelectList(objServicio, "ServicioID", "NombreServicio", 0);
                }
            }
            return Json(obgServicio, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetProviderData(int? servicioId)
        {
            SelectList obgProveedor = new SelectList("");
            if (servicioId != null)
            {
                Servicio s = db.Servicios.FirstOrDefault(m => m.ServicioID == servicioId);
                if (s != null)
                {
                    List<Proveedor> objProveedor = new List<Proveedor>();
                    objProveedor = s.Proveedores.ToList<Proveedor>();
                    obgProveedor = new SelectList(objProveedor, "Rut", "NombreFantasia", 0);
                }
            }
            return Json(obgProveedor, JsonRequestBehavior.AllowGet);
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
        [HttpGet]
        public ActionResult AddService(int? serviceValue, string providerValue, string data)
        {
            try
            {
                if (serviceValue != null && providerValue != null)
                {
                    Servicio servicio = db.Servicios.FirstOrDefault(s => s.ServicioID == serviceValue);
                    Proveedor proveedor = db.Proveedores.FirstOrDefault(s => s.Rut == providerValue);
                    ServicioProveedor sp = new ServicioProveedor() {
                        IdServicio = servicio.ServicioID, NombreServicio = servicio.NombreServicio, IdProveedor = proveedor.Rut, NombreProveedor = proveedor.NombreFantasia
                    };
                    model.ServiciosSeleccionados.Add(sp);
                    return PartialView("ServicioProveedorView", model);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult GetServicioProveedor()
        {
            //var model = new EventoViewModels();
            return PartialView("ServicioProveedor", model);
        }
    }
}
