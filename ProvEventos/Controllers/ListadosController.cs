using ProvEventos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProvEventos.Controllers
{
    public class ListadosController : Controller
    {
        private ProvEventosContext db = new ProvEventosContext();
        // GET: Listados
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult Organizadores()
        {
            String nombreUsuario = this.User.Identity.Name;
            if (nombreUsuario != null && nombreUsuario != "")
            {
                Usuario usu = db.Usuarios.AsEnumerable().FirstOrDefault(u => u.NombreUsuario == nombreUsuario);
                if (usu.Rol.Roles == Roles.Administrador)
                {
                    IEnumerable<ProvEventos.Models.Organizador> organizadores;

                    organizadores = db.Organizadores.ToList();

                    return View(organizadores);
                }
                else
                    return View("Forbidden");
            }
            else
            {
                return View("Forbidden");
            }
            
        }

        /*
        // GET: Listados/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Listados/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Listados/Create
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

        // GET: Listados/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Listados/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Listados/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Listados/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        */
    }
}
