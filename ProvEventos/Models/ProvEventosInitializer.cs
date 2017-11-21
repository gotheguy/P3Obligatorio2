using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;

namespace ProvEventos.Models
{
    public class ProvEventosInitializer : DropCreateDatabaseAlways<ProvEventosContext>
    {
        protected override void Seed(ProvEventosContext context)
        {
            var roles = new List<Rol>
            {
                new Rol { RolID = 1, Roles = Roles.Administrador },
                new Rol { RolID = 2, Roles = Roles.Organizador },
                new Rol { RolID = 3, Roles = Roles.Proveedor }
            };

            roles.ForEach(s => context.Roles.Add(s));
            context.SaveChanges();

            if (!context.Roles.Any(r => r.Roles == Roles.Administrador))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Administrador" };

                manager.Create(role);

            }

            if (!context.Roles.Any(r => r.Roles == Roles.Organizador))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Organizador" };

                manager.Create(role);
            }

            if (!context.Roles.Any(r => r.Roles == Roles.Proveedor))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Proveedor" };

                manager.Create(role);
            }


            var usuarios = new List<Usuario>
            {
                new Usuario{NombreUsuario="cossav@hotmail.com",Clave="Aap..2332",FechaRegistro=DateTime.Parse("2013-01-04"),Rol = roles[0] },
                new Usuario{NombreUsuario="fmds34@gmail.com",Clave="24mw*32S",FechaRegistro=DateTime.Parse("2016-05-24"),Rol = roles[0]},
                new Usuario{NombreUsuario="javi3@hotmail.com",Clave="oMFDS43t3#",FechaRegistro=DateTime.Parse("2015-01-03"),Rol = roles[2]},
                new Usuario{NombreUsuario="apapf@gmail.com",Clave="AIFNis3$ds",FechaRegistro=DateTime.Parse("2017-04-04"),Rol = roles[1]},
                new Usuario{NombreUsuario="sapp@gmail.com",Clave="AOIrgn34&&",FechaRegistro=DateTime.Parse("2017-12-12"),Rol = roles[2]},
                new Usuario{NombreUsuario="mansv@gmail.com",Clave="#%YsfgsaAS",FechaRegistro=DateTime.Parse("2016-07-27"),Rol = roles[0]},
                new Usuario{NombreUsuario="parest@hotmail.com",Clave="42tAAF43!",FechaRegistro=DateTime.Parse("2015-11-24"),Rol = roles[0]},
                new Usuario{NombreUsuario="oasf444@hotmail.com",Clave="het45$GGht4",FechaRegistro=DateTime.Parse("2016-02-28"),Rol = roles[2]},
                new Usuario{NombreUsuario="persist@gmail.com",Clave="#$g3G#%gGGe",FechaRegistro=DateTime.Parse("2017-07-12"),Rol = roles[2]},
                new Usuario{NombreUsuario="pasfa@hotmail.com",Clave="//2T$gegFS4",FechaRegistro=DateTime.Parse("2017-05-30"),Rol = roles[1]},
                new Usuario{NombreUsuario="arsti@gmail.com",Clave="$#g3%$G$%af",FechaRegistro=DateTime.Parse("2016-01-15"),Rol = roles[1]},
                new Usuario{NombreUsuario="cmoar@hotmail.com",Clave="#T3g%hhfg",FechaRegistro=DateTime.Parse("2014-01-21"),Rol = roles[2]}
            };

            usuarios.ForEach(s => context.Usuarios.Add(s));
            context.SaveChanges();



            //try
            //{
            //    var organizadores = new List<Organizador>
            //    {
            //        new Organizador {
            //            NombreOrganizador = "proevisa",
            //            Email = "proevisa@hotmail.com",
            //            UsuarioID=4
            //        }
            //    };
            //    organizadores.ForEach(s => context.Organizadores.Add(s));
            //    context.SaveChanges();
            //}
            //catch (DbEntityValidationException e)
            //{
            //    foreach (var eve in e.EntityValidationErrors)
            //    {
            //        Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
            //            eve.Entry.Entity.GetType().Name, eve.Entry.State);
            //        foreach (var ve in eve.ValidationErrors)
            //        {
            //            Console.WriteLine("- Property: \"{0}\", Value: \"{1}\", Error: \"{2}\"",
            //                ve.PropertyName,
            //                eve.Entry.CurrentValues.GetValue<object>(ve.PropertyName),
            //                ve.ErrorMessage);
            //        }
            //    }
            //    throw;
            //}





            try
            {   // Open the text file using a stream reader.
                List<Servicio> servicios = new List<Servicio>();
                string serviceFile = AppDomain.CurrentDomain.BaseDirectory + @"\App_data\FileServicios.txt";
                string providerFile = AppDomain.CurrentDomain.BaseDirectory + @"\App_data\FileProveedores.txt";
                using (StreamReader sr = new StreamReader(serviceFile))
                {
                    string line = "";
                    while ((line = sr.ReadLine()) != null)
                    {
                        List<string> data = line.Split('#').ToList();
                        Servicio s = new Servicio()
                        {
                            NombreServicio = data[0]
                        };
                        if (s.TipoEvento == null) s.TipoEvento = new List<Tipo_Evento>();
                        string datosTipo = data[1];
                        List<string> dataTipo = datosTipo.Split(':').ToList();
                        if (datosTipo.Length != 0)
                        {
                            foreach (string tipo in dataTipo)
                            {
                                Tipo_Evento tEvento = new Tipo_Evento() { NombreTipoEvento = tipo };
                                s.TipoEvento.Add(tEvento);
                            }
                        }
                        servicios.Add(s);
                    }
                    sr.Close();
                }
                
                servicios.ForEach(ser => context.Servicios.Add(ser));
                context.SaveChanges();

                List<Proveedor> proveedores = new List<Proveedor>();
                using (StreamReader sr = new StreamReader(providerFile))
                {
                    string line = "";
                    while ((line = sr.ReadLine()) != null)
                    {
                        List<string> data = line.Split('#').ToList();
                        Proveedor p = new Proveedor()
                        {
                            NombreUsuario = data[2],
                            Rut = data[0],
                            NombreFantasia = data[1],
                            Email = data[2],
                            Activo = true,
                            Clave = "Pass1234!",
                            FechaRegistro = DateTime.Today,
                            RolID = 3
                        };
                        Telefono t = new Telefono() { Numero = data[3] };
                        if (p.Telefonos == null) p.Telefonos = new List<Telefono>();
                        p.Telefonos.Add(t);
                        if (p.Servicios == null) p.Servicios = new List<Servicio>();
                        List<string> serv = data.Where((item, index) => index > 3).ToList();
                        foreach (string s in serv)
                        {
                            string[] dataServ = s.Split(':');
                            Servicio servicio = context.Servicios.AsEnumerable().FirstOrDefault(c => c.NombreServicio == dataServ[0]);
                            servicio.Descripcion = dataServ[1];
                            servicio.Imagen = dataServ[2] != "No hay imagen disponible" ? dataServ[2]:"";
                            p.Servicios.Add(servicio);
                        }
                        var usuario = new Usuario
                        {
                            NombreUsuario = p.Email,
                            Clave = "Pass1234!",
                            FechaRegistro = DateTime.Today,
                            RolID = 3
                        };
                        p.Usuario = usuario;
                        proveedores.Add(p);
                    }
                    sr.Close();
                }
                proveedores.ForEach(p => context.Proveedores.Add(p));
                context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Console.WriteLine("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }
    }
}