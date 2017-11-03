using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProvEventos.Models
{
    public class Organizador : Usuario
    {
        public string Email { get; set; }
        public string Telefono { get; set; }
    }
}