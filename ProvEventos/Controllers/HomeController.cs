using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Web;
using System.Web.Mvc;
using ProvEventos.Models;

namespace ProvEventos.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Usuario objUser)
        {
            if (ModelState.IsValid)
            {
                using (ProvEventosContext db = new ProvEventosContext())
                {
                    var obj = db.Usuarios.Where(a => a.NombreUsuario.Equals(objUser.NombreUsuario) && a.Clave.Equals(objUser.Clave)).FirstOrDefault();
                    if (obj != null)
                    {
                        Session["UsuarioID"] = obj.UsuarioID.ToString();
                        Session["NombreUsuario"] = obj.NombreUsuario.ToString();
                        return RedirectToAction("UserDashBoard");
                    }
                }
            }
            return View(objUser);
        }

        public ActionResult UserDashBoard()
        {
            if (Session["UsuarioID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
    }
}