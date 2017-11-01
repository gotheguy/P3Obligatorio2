using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProvEventos.Models
{
    public class Rol
    {
        public enum Roles
        {
            Proveedor,
            Administrador,
            Organizador
        }
    }
}