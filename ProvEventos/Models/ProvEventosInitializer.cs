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

            //var organizadores = new List<Organizador>
            //{
            //    new Organizador {UsuarioID=1,
            //    NombreOrganizador="Proevisa",Email="proevisa@hotmail.com"}
            //};

            //organizadores.ForEach(s => context.Organizadores.Add(s));


            try
            {   // Open the text file using a stream reader.
                List<Servicio> servicios = new List<Servicio>();
                string serviceFile = @"~\App_data\FileServicios.txt";
                string providerFile = @"~\App_data\FileProveedores.txt";
                using (StreamReader sr = new StreamReader(serviceFile))
                {
                    // Read the stream to a string, and write the string to the console.
                    string line = "";
                    while ((line = sr.ReadLine()) != null)
                    {
                        List<string> data = line.Split('#').ToList();
                        Servicio s = new Servicio()
                        {
                            NombreServicio = data[0]
                        };
                        if (s.TipoEvento == null) s.TipoEvento = new List<Tipo_Evento>();
                        List<string> dataTipo = data.Where((item, index) => index > 0).ToList();
                        foreach (string tipo in dataTipo)
                        {
                            Tipo_Evento tEvento = new Tipo_Evento() { NombreTipoEvento = tipo };
                            s.TipoEvento.Add(tEvento);
                        }
                        servicios.Add(s);
                    }
                    sr.Close();
                }

                List<Proveedor> proveedores = new List<Proveedor>();
                using (StreamReader sr = new StreamReader(providerFile))
                {
                    // Read the stream to a string, and write the string to the console.
                    string line = "";
                    while ((line = sr.ReadLine()) != null)
                    {
                        List<string> data = line.Split('#').ToList();
                        Proveedor p = new Proveedor()
                        {
                            Rut = data[0],
                            NombreFantasia = data[1],
                            Email = data[2],
                            Activo = true
                        };
                        Telefono t = new Telefono() { Numero = data[3] };
                        if (p.Telefonos == null) p.Telefonos = new List<Telefono>();
                        p.Telefonos.Add(t);
                        if (p.Servicios == null) p.Servicios = new List<Servicio>();
                        List<string> serv = data.Where((item, index) => index > 3).ToList();
                        foreach (string s in serv)
                        {
                            string[] dataServ = s.Split(':');
                            Servicio servicio = context.Servicios.FirstOrDefault(c => c.NombreServicio == dataServ[0]);
                            p.Servicios.Add(servicio);
                        }
                        proveedores.Add(p);
                    }
                    sr.Close();
                }            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
            context.SaveChanges();
        }
    }
}