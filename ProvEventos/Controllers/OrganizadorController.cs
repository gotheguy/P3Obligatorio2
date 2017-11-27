using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProvEventos.Models;

namespace ProvEventos.Controllers
{
    public class OrganizadorController : Controller
    {
        private ProvEventosContext db = new ProvEventosContext();

        // GET: Organizador
        public ActionResult Index()
        {
            return View(db.Organizadores.ToList());
        }

        // GET: Organizador/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Organizador organizador = db.Organizadores.Find(id);
            if (organizador == null)
            {
                return HttpNotFound();
            }
            return View(organizador);
        }

        // GET: Organizador/Create
        public ActionResult Create()
        {
            ViewBag.UsuarioID = new SelectList(db.Usuarios, "UsuarioID", "NombreUsuario");
            return View();
        }

        // POST: Organizador/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "zNombreUsuario,Clave,FechaRegistro,Rol,NombreOrganizador,Email")] Organizador organizador)
        {
            if (ModelState.IsValid)
            {
                db.Usuarios.Add(organizador);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UsuarioID = new SelectList(db.Usuarios, "UsuarioID", "NombreUsuario", organizador.Id);
            return View(organizador);
        }

        // GET: Organizador/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Organizador organizador = db.Organizadores.Find(id);
            if (organizador == null)
            {
                return HttpNotFound();
            }
            ViewBag.UsuarioID = new SelectList(db.Usuarios, "UsuarioID", "NombreUsuario", organizador.Id);
            return View(organizador);
        }

        // POST: Organizador/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UsuarioID,NombreUsuario,Clave,FechaRegistro,Rol,NombreOrganizador,Email")] Organizador organizador)
        {
            if (ModelState.IsValid)
            {
                db.Entry(organizador).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UsuarioID = new SelectList(db.Usuarios, "UsuarioID", "NombreUsuario", organizador.Id);
            return View(organizador);
        }

        // GET: Organizador/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Organizador organizador = db.Organizadores.Find(id);
            if (organizador == null)
            {
                return HttpNotFound();
            }
            return View(organizador);
        }

        // POST: Organizador/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Organizador organizador = db.Organizadores.Find(id);
            db.Usuarios.Remove(organizador);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
