using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Web;
using Microsoft.Owin;

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




            var organizadores = new List<Organizador>
            {
                new Organizador{NombreUsuario="cossav@hotmail.com", Clave = "PPpp.2017",FechaRegistro = DateTime.Now,RolID = 2,NombreOrganizador = "Roberto Rodriguez",Email = "cossav@hotmail.com",Telefono = "099265587"},
                new Organizador{NombreUsuario="asse@hotmail.com", Clave = "AAaa.2015",FechaRegistro = DateTime.Now,RolID = 2,NombreOrganizador = "Camilo Ferreira",Email = "asse@hotmail.com",Telefono = "098925255"},
                new Organizador{NombreUsuario="proevisa@hotmail.com", Clave = "VVvv.2012",FechaRegistro = DateTime.Now,RolID = 2,NombreOrganizador = "Eduardo Freire",Email = "proevisa@hotmail.com",Telefono = "095898774"}
            };

            organizadores.ForEach(s => context.Organizadores.Add(s));
            context.SaveChanges();

            //foreach(Organizador o in organizadores)
            //{
            //    var store = new UserStore<ApplicationUser>(context);
            //    var manager = new UserManager<ApplicationUser>(store);
            //    var user = new ApplicationUser { UserName = o.NombreUsuario };

            //    manager.Create(user, o.Clave);
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
                            Telefono = data[3],
                            FechaRegistro = DateTime.Today,
                            RolID = 3
                        };
                        if (p.Servicios == null) p.Servicios = new List<Servicio>();
                        List<string> serv = data.Where((item, index) => index > 3).ToList();
                        foreach (string s in serv)
                        {
                            string[] dataServ = s.Split(':');
                            Servicio servicio = context.Servicios.AsEnumerable().FirstOrDefault(c => c.NombreServicio == dataServ[0]);
                            servicio.Descripcion = dataServ[1];
                            servicio.Imagen = dataServ[2] != "No hay imagen disponible" ? dataServ[2] : "";
                            p.Servicios.Add(servicio);
                        }
                        //var usuario = new Usuario
                        //{
                        //    NombreUsuario = p.Email,
                        //    Clave = "Pass1234!",
                        //    FechaRegistro = DateTime.Today,
                        //    RolID = 3
                        //};
                        //p.Usuario = usuario;
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