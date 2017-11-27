namespace ProvEventos.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Validation;
    using System.IO;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ProvEventos.Models.ProvEventosContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ProvEventos.Models.ProvEventosContext context)
        {
            context.Roles.AddOrUpdate(
                p => p.RolID,
                new Rol { RolID = 1, Roles = Roles.Administrador },
                new Rol { RolID = 2, Roles = Roles.Organizador },
                new Rol { RolID = 3, Roles = Roles.Proveedor }
                );

            var hasher = new PasswordHasher();

            context.Organizadores.AddOrUpdate(
                p => p.UserName,
                new Organizador { UserName = "cossav@hotmail.com", PasswordHash = hasher.HashPassword("PPpp.2017"), Email = "cossav@hotmail.com", PhoneNumber = "099265587", SecurityStamp = Guid.NewGuid().ToString(), FechaRegistro = DateTime.Now, RolID = 2, NombreOrganizador = "Roberto Rodriguez", Telefono = "099265587" },
                new Organizador { UserName = "asse@hotmail.com", PasswordHash = hasher.HashPassword("AAaa.2015"), Email = "asse@hotmail.com", PhoneNumber = "098925255", SecurityStamp = Guid.NewGuid().ToString(), FechaRegistro = DateTime.Now, RolID = 2, NombreOrganizador = "Camilo Ferreira", Telefono = "098925255" },
                new Organizador { UserName = "proevisa@hotmail.com", PasswordHash = hasher.HashPassword("SSss.2013"), Email = "proevisa@hotmail.com", PhoneNumber = "095898774", SecurityStamp = Guid.NewGuid().ToString(), FechaRegistro = DateTime.Now, RolID = 2, NombreOrganizador = "Eduardo Freire", Telefono = "095898774" },
                new Organizador { UserName = "veaze@hotmail.com", PasswordHash = hasher.HashPassword("RRrr.2017"), Email = "veaze@hotmail.com", PhoneNumber = "099898778", SecurityStamp = Guid.NewGuid().ToString(), FechaRegistro = DateTime.Now, RolID = 2, NombreOrganizador = "Arnoldo Montez", Telefono = "099898778" },
                new Organizador { UserName = "pring@hotmail.com", PasswordHash = hasher.HashPassword("YYyy.2011"), Email = "pring@hotmail.com", PhoneNumber = "095523695", SecurityStamp = Guid.NewGuid().ToString(), FechaRegistro = DateTime.Now, RolID = 2, NombreOrganizador = "Pedro Noli", Telefono = "095523695" },
                new Organizador { UserName = "ddl@hotmail.com", PasswordHash = hasher.HashPassword("JJjj.2012"), Email = "ddl@hotmail.com", PhoneNumber = "099877077", SecurityStamp = Guid.NewGuid().ToString(), FechaRegistro = DateTime.Now, RolID = 2, NombreOrganizador = "Walter Rojas", Telefono = "099877077" },
                new Organizador { UserName = "lenoit@hotmail.com", PasswordHash = hasher.HashPassword("TTtt.2017"), Email = "lenoit@hotmail.com", PhoneNumber = "099123658", SecurityStamp = Guid.NewGuid().ToString(), FechaRegistro = DateTime.Now, RolID = 2, NombreOrganizador = "Leonardo Sereno", Telefono = "099123658" },
                new Organizador { UserName = "notable@hotmail.com", PasswordHash = hasher.HashPassword("FFff.2016"), Email = "notable@hotmail.com", PhoneNumber = "098752585", SecurityStamp = Guid.NewGuid().ToString(), FechaRegistro = DateTime.Now, RolID = 2, NombreOrganizador = "Alejandro Castro", Telefono = "098752585" },
                new Organizador { UserName = "hvlc@hotmail.com", PasswordHash = hasher.HashPassword("QQqq.2014"), Email = "hvlc@hotmail.com", PhoneNumber = "098989999", SecurityStamp = Guid.NewGuid().ToString(), FechaRegistro = DateTime.Now, RolID = 2, NombreOrganizador = "Alfonso Rivero", Telefono = "098989999" }
                );

            context.Administradores.AddOrUpdate(
                p => p.UserName,
                new Administrador { UserName = "robertohernandez@hotmail.com", PasswordHash = hasher.HashPassword("UUuu.2016"), Email = "robertohernandez@hotmail.com", PhoneNumber = "099563254", SecurityStamp = Guid.NewGuid().ToString(), FechaRegistro = DateTime.Now, RolID = 1 },
                new Administrador { UserName = "fmoreno@gmail.com", PasswordHash = hasher.HashPassword("ZZzz.2013"), Email = "fmoreno@hotmail.com", PhoneNumber = "095669215", SecurityStamp = Guid.NewGuid().ToString(), FechaRegistro = DateTime.Now, RolID = 1 },
                new Administrador { UserName = "edu093@gmail.com", PasswordHash = hasher.HashPassword("HHhh.2015"), Email = "edu093@gmail.com", PhoneNumber = "099639865", SecurityStamp = Guid.NewGuid().ToString(), FechaRegistro = DateTime.Now, RolID = 1 }
                );


            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            
            var user = new ApplicationUser { UserName = "cossav@hotmail.com", Email = "cossav@hotmail.com", PasswordHash = hasher.HashPassword("PPpp.2017") };
            UserManager.Create(user);
            user = new ApplicationUser { UserName = "asse@hotmail.com", Email = "asse@hotmail.com", PasswordHash = hasher.HashPassword("AAaa.2015") };
            UserManager.Create(user);
            user = new ApplicationUser { UserName = "proevisa@hotmail.com", Email = "proevisa@hotmail.com", PasswordHash = hasher.HashPassword("SSss.2013") };
            UserManager.Create(user);
            user = new ApplicationUser { UserName = "veaze@hotmail.com", Email = "veaze@hotmail.com", PasswordHash = hasher.HashPassword("RRrr.2017") };
            UserManager.Create(user);
            user = new ApplicationUser { UserName = "pring@hotmail.com", Email = "pring@hotmail.com", PasswordHash = hasher.HashPassword("YYyy.2011") };
            UserManager.Create(user);
            user = new ApplicationUser { UserName = "ddl@hotmail.com", Email = "ddl@hotmail.com", PasswordHash = hasher.HashPassword("JJjj.2012") };
            UserManager.Create(user);
            user = new ApplicationUser { UserName = "lenoit@hotmail.com", Email = "lenoit@hotmail.com", PasswordHash = hasher.HashPassword("TTtt.2017") };
            UserManager.Create(user);
            user = new ApplicationUser { UserName = "notable@hotmail.com", Email = "notable@hotmail.com", PasswordHash = hasher.HashPassword("FFff.2016") };
            UserManager.Create(user);
            user = new ApplicationUser { UserName = "hvlc@hotmail.com", Email = "hvlc@hotmail.com", PasswordHash = hasher.HashPassword("QQqq.2014") };
            UserManager.Create(user);
            user = new ApplicationUser { UserName = "robertohernandez@hotmail.com", Email = "robertohernandez@hotmail.com", PasswordHash = hasher.HashPassword("UUuu.2016") };
            UserManager.Create(user);
            user = new ApplicationUser { UserName = "fmoreno@gmail.com", Email = "fmoreno@gmail.com", PasswordHash = hasher.HashPassword("ZZzz.2013") };
            UserManager.Create(user);
            user = new ApplicationUser { UserName = "edu093@gmail.com", Email = "edu093@gmail.com", PasswordHash = hasher.HashPassword("HHhh.2015") };
            UserManager.Create(user);



            //try
            //{   // Open the text file using a stream reader.
            //    List<Servicio> servicios = new List<Servicio>();
            //    string serviceFile = AppDomain.CurrentDomain.BaseDirectory + @"\App_data\FileServicios.txt";
            //    string providerFile = AppDomain.CurrentDomain.BaseDirectory + @"\App_data\FileProveedores.txt";
            //    using (StreamReader sr = new StreamReader(serviceFile))
            //    {
            //        string line = "";
            //        while ((line = sr.ReadLine()) != null)
            //        {
            //            List<string> data = line.Split('#').ToList();
            //            Servicio s = new Servicio()
            //            {
            //                NombreServicio = data[0]
            //            };
            //            if (s.TipoEvento == null) s.TipoEvento = new List<Tipo_Evento>();
            //            string datosTipo = data[1];
            //            List<string> dataTipo = datosTipo.Split(':').ToList();
            //            if (datosTipo.Length != 0)
            //            {
            //                foreach (string tipo in dataTipo)
            //                {
            //                    Tipo_Evento tEvento = new Tipo_Evento() { NombreTipoEvento = tipo };
            //                    s.TipoEvento.Add(tEvento);
            //                }
            //            }
            //            servicios.Add(s);
            //        }
            //        sr.Close();
            //    }

            //    servicios.ForEach(ser => context.Servicios.Add(ser));
            //    context.SaveChanges();

            ////    List<Proveedor> proveedores = new List<Proveedor>();
            ////    using (StreamReader sr = new StreamReader(providerFile))
            ////    {
            ////        string line = "";
            ////        while ((line = sr.ReadLine()) != null)
            ////        {
            ////            List<string> data = line.Split('#').ToList();
            ////            Proveedor p = new Proveedor()
            ////            {
            ////                UserName = data[2],
            ////                PasswordHash = hasher.HashPassword("Pass1234!"),
            ////                Email = data[2],
            ////                FechaRegistro = DateTime.Now,
            ////                RolID = 3,
            ////                Rut = data[0],
            ////                NombreFantasia = data[1],
            ////                Telefono = data[3],
            ////                Activo = true,
            ////                VIP = true
            ////            };
            ////            if (p.Servicios == null) p.Servicios = new List<Servicio>();
            ////            List<string> serv = data.Where((item, index) => index > 3).ToList();
            ////            foreach (string s in serv)
            ////            {
            ////                string[] dataServ = s.Split(':');
            ////                Servicio servicio = context.Servicios.AsEnumerable().FirstOrDefault(c => c.NombreServicio == dataServ[0]);
            ////                servicio.Descripcion = dataServ[1];
            ////                servicio.Imagen = dataServ[2] != "No hay imagen disponible" ? dataServ[2] : "";
            ////                p.Servicios.Add(servicio);
            ////            }
            ////            proveedores.Add(p);
            ////        }
            ////        sr.Close();
            ////    }
            ////    proveedores.ForEach(p => context.Proveedores.Add(p));
            ////    context.SaveChanges();
            //}
            //catch (DbEntityValidationException dbEx)
            //{
            //    foreach (var validationErrors in dbEx.EntityValidationErrors)
            //    {
            //        foreach (var validationError in validationErrors.ValidationErrors)
            //        {
            //            Console.WriteLine("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
            //        }
            //    }
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine("The file could not be read:");
            //    Console.WriteLine(e.Message);
            //}
        }
    }
}
