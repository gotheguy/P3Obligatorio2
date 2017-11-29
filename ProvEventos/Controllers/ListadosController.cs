﻿using ProvEventos.Models;
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
                Usuario usu = db.Usuarios.AsEnumerable().FirstOrDefault(u => u.UserName == nombreUsuario);
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

        public ActionResult Eventos()
        {
            String nombreUsuario = User.Identity.Name;
            if (nombreUsuario != null && nombreUsuario != "")
            {
                Usuario usu = db.Usuarios.AsEnumerable().FirstOrDefault(u => u.UserName == nombreUsuario);

                var eventos = from p in db.Eventos
                              where p.Organizador.Id == usu.Id
                              select p;

                return View(eventos);
            }
            else
            {
                return View("Forbidden");
            }
        }
    }
}
