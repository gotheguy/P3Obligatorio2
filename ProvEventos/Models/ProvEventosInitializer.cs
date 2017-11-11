using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using ProvEventos.Models;

namespace ProvEventos.Models 
{
    public class ProvEventosInitializer : DropCreateDatabaseIfModelChanges<ProvEventosContext>
    {
        protected override void Seed(ProvEventosContext context)
        {
            var usuarios = new List<Usuario>
            {
                new Usuario{NombreUsuario="Gonzalo Otheguy",Clave="12345678",FechaRegistro=DateTime.Parse("2013-01-04"),Rol = Rol.Roles.Administrador},
                new Usuario{NombreUsuario="Pablo García",Clave="987654321",FechaRegistro=DateTime.Parse("2016-05-24"),Rol = Rol.Roles.Administrador},
                new Usuario{NombreUsuario="Javier Mesa",Clave="25434534",FechaRegistro=DateTime.Parse("2015-01-03"),Rol = Rol.Roles.Proveedor},
                new Usuario{NombreUsuario="Rodrigo Alvez",Clave="674624534",FechaRegistro=DateTime.Parse("2017-04-04"),Rol = Rol.Roles.Organizador},
                new Usuario{NombreUsuario="Walter Perez",Clave="563675673",FechaRegistro=DateTime.Parse("2017-12-12"),Rol = Rol.Roles.Proveedor},
                new Usuario{NombreUsuario="Sebastián Rocha",Clave="42713546",FechaRegistro=DateTime.Parse("2016-07-27"),Rol = Rol.Roles.Administrador}
            };

            usuarios.ForEach(s => context.Usuarios.Add(s));
            context.SaveChanges();

        }
    }
}