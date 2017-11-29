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
    public class ProvEventosInitializer : DropCreateDatabaseIfModelChanges<ProvEventosContext>
    {
        protected override void Seed(ProvEventosContext context)
        {


            //    try
            //    {   // Open the text file using a stream reader.
            //        List<Servicio> servicios = new List<Servicio>();
            //        string serviceFile = AppDomain.CurrentDomain.BaseDirectory + @"\App_data\FileServicios.txt";
            //        string providerFile = AppDomain.CurrentDomain.BaseDirectory + @"\App_data\FileProveedores.txt";
            //        using (StreamReader sr = new StreamReader(serviceFile))
            //        {
            //            string line = "";
            //            while ((line = sr.ReadLine()) != null)
            //            {
            //                List<string> data = line.Split('#').ToList();
            //                Servicio s = new Servicio()
            //                {
            //                    NombreServicio = data[0]
            //                };
            //                if (s.TipoEvento == null) s.TipoEvento = new List<Tipo_Evento>();
            //                string datosTipo = data[1];
            //                List<string> dataTipo = datosTipo.Split(':').ToList();
            //                if (datosTipo.Length != 0)
            //                {
            //                    foreach (string tipo in dataTipo)
            //                    {
            //                        Tipo_Evento tEvento = new Tipo_Evento() { NombreTipoEvento = tipo };
            //                        s.TipoEvento.Add(tEvento);
            //                    }
            //                }
            //                servicios.Add(s);
            //            }
            //            sr.Close();
            //        }

            //        servicios.ForEach(ser => context.Servicios.Add(ser));
            //        context.SaveChanges();

            //        List<Proveedor> proveedores = new List<Proveedor>();
            //        using (StreamReader sr = new StreamReader(providerFile))
            //        {
            //            string line = "";
            //            while ((line = sr.ReadLine()) != null)
            //            {
            //                List<string> data = line.Split('#').ToList();
            //                Proveedor p = new Proveedor()
            //                {
                            //UserName = data[2],
                            //PasswordHash = hasher.HashPassword("Pass1234!"),
                            //Email = data[2],
                            //PhoneNumber = data[3],
                            //SecurityStamp = Guid.NewGuid().ToString(),
                            //FechaRegistro = DateTime.Now,
                            //RolID = 3,
                            //Rut = data[0],
                            //NombreFantasia = data[1],
                            //Telefono = data[3],
                            //Activo = true,
                            //VIP = true
            //                };
            //                if (p.Servicios == null) p.Servicios = new List<Servicio>();
            //                List<string> serv = data.Where((item, index) => index > 3).ToList();
            //                foreach (string s in serv)
            //                {
            //                    string[] dataServ = s.Split(':');
            //                    Servicio servicio = context.Servicios.AsEnumerable().FirstOrDefault(c => c.NombreServicio == dataServ[0]);
            //                    servicio.Descripcion = dataServ[1];
            //                    servicio.Imagen = dataServ[2] != "No hay imagen disponible" ? dataServ[2] : "No hay imagen disponible";
            //                    p.Servicios.Add(servicio);
            //                }
            //                //var usuario = new Usuario
            //                //{
            //                //    NombreUsuario = p.Email,
            //                //    Clave = "Pass1234!",
            //                //    FechaRegistro = DateTime.Today,
            //                //    RolID = 3
            //                //};
            //                //p.Usuario = usuario;
            //                proveedores.Add(p);
            //            }
            //            sr.Close();
            //        }
            //        proveedores.ForEach(p => context.Proveedores.Add(p));
            //        context.SaveChanges();
            //    }
            //    catch (DbEntityValidationException dbEx)
            //    {
            //        foreach (var validationErrors in dbEx.EntityValidationErrors)
            //        {
            //            foreach (var validationError in validationErrors.ValidationErrors)
            //            {
            //                Console.WriteLine("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
            //            }
            //        }
            //    }
            //    catch (Exception e)
            //    {
            //        Console.WriteLine("The file could not be read:");
            //        Console.WriteLine(e.Message);
            //    }
        }
    }
}