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
    public class Tipo_EventoController : Controller
    {
        // GET: Tipo_Evento
        public ActionResult Index()
        {
            return View();
        }
    }
}