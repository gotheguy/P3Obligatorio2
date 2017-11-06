using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using ProvEventos.Models;

namespace ProvEventos.Models 
{
    public class ProvEventosInitializer : DropCreateDatabaseAlways<ProvEventosContext>
    {
        protected override void Seed(ProvEventosContext context)
        {
            var usuarios = new List<Usuario>
            {
                new Usuario{Nombre="R2521955",Clave="12345678",FechaRegistro=DateTime.Parse("2013-01-04"),Rol = Rol.Tipo.Administrador}
            };

            usuarios.ForEach(s => context.Usuarios.Add(s));
            context.SaveChanges();
        }
    }
}