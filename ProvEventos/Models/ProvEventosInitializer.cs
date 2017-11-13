using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using ProvEventos.Models;
using System.IO;

namespace ProvEventos.Models 
{
    public class ProvEventosInitializer : DropCreateDatabaseIfModelChanges<ProvEventosContext>
    {
        protected override void Seed(ProvEventosContext context)
        {
            var usuarios = new List<Usuario>
            {
                new Usuario{NombreUsuario="Gonzalo Frade",Clave="23523523",FechaRegistro=DateTime.Parse("2013-01-04"),Rol = Rol.Roles.Administrador},
                new Usuario{NombreUsuario="Pablo García",Clave="98765432",FechaRegistro=DateTime.Parse("2016-05-24"),Rol = Rol.Roles.Administrador},
                new Usuario{NombreUsuario="Javier Mesa",Clave="25434534",FechaRegistro=DateTime.Parse("2015-01-03"),Rol = Rol.Roles.Proveedor},
                new Usuario{NombreUsuario="Rodrigo Alvez",Clave="67462454",FechaRegistro=DateTime.Parse("2017-04-04"),Rol = Rol.Roles.Organizador},
                new Usuario{NombreUsuario="Walter Perez",Clave="56365673",FechaRegistro=DateTime.Parse("2017-12-12"),Rol = Rol.Roles.Proveedor},
                new Usuario{NombreUsuario="Sebastián Rocha",Clave="42733546",FechaRegistro=DateTime.Parse("2016-07-27"),Rol = Rol.Roles.Administrador},
                new Usuario{NombreUsuario="Facundo Martinez",Clave="26354554",FechaRegistro=DateTime.Parse("2015-11-24"),Rol = Rol.Roles.Administrador},
                new Usuario{NombreUsuario="Matías Herrera",Clave="47537834",FechaRegistro=DateTime.Parse("2016-02-28"),Rol = Rol.Roles.Proveedor},
                new Usuario{NombreUsuario="Diego Gomez",Clave="11325256",FechaRegistro=DateTime.Parse("2017-07-12"),Rol = Rol.Roles.Proveedor},
                new Usuario{NombreUsuario="Ramiro Franco",Clave="54578447",FechaRegistro=DateTime.Parse("2017-05-30"),Rol = Rol.Roles.Organizador},
                new Usuario{NombreUsuario="Hernán Palacios",Clave="97995634",FechaRegistro=DateTime.Parse("2016-01-15"),Rol = Rol.Roles.Proveedor},
                new Usuario{NombreUsuario="Camilo Moar",Clave="25233666",FechaRegistro=DateTime.Parse("2014-01-21"),Rol = Rol.Roles.Proveedor}
            };

            usuarios.ForEach(s => context.Usuarios.Add(s));
            context.SaveChanges();


            var file = File.ReadAllText(@"~\App_Data\FileServicios.txt");
        }
    }
}