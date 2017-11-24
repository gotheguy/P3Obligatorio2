using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using ProvEventos.Models;

namespace ProvEventos.Models
{
    public class ProvEventosContext : DbContext
    {
        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<Servicio> Servicios { get; set; }
        public DbSet<Tipo_Evento> Tipo_Eventos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Administrador> Administradores { get; set; }
        public DbSet<Organizador> Organizadores { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Telefono> Telefonos { get; set; }
        public DbSet<Evento> Eventos { get; set; }

        public ProvEventosContext() : base("name=ProvEventos")
        {
        }
         
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}