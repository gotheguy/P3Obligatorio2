using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using ProvEventos.Models;
using Microsoft.AspNet.Identity.EntityFramework;


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
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Calificacion> Calificaciones { get; set; }

        public ProvEventosContext() : base("name=ProvEventos")
        {
        }
         
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<IdentityUserLogin>().ToTable("AspNetUserLogins").HasKey<string>(l => l.UserId);
            modelBuilder.Entity<IdentityRole>().ToTable("AspNetRoles").HasKey<string>(r => r.Id);
            modelBuilder.Entity<IdentityUserRole>().ToTable("AspNetUserRoles").HasKey(r => new { r.RoleId, r.UserId });
            modelBuilder.Entity<IdentityUserClaim>().ToTable("AspNetUserClaims").HasKey<string>(l => l.UserId);
            modelBuilder.Entity<ApplicationUser>().ToTable("AspNetUsers");
        }
    }
}