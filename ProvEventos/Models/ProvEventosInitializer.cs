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
                new Usuario{NombreUsuario="Gonzalo Otheguy",Clave="12345678",FechaRegistro=DateTime.Parse("2013-01-04"),Rol = Rol.Roles.Administrador},
                new Usuario{NombreUsuario="Pablo García",Clave="987654321",FechaRegistro=DateTime.Parse("2016-05-24"),Rol = Rol.Roles.Administrador}
            };

            usuarios.ForEach(s => context.Usuarios.Add(s));
            context.SaveChanges();
        }
    }
}