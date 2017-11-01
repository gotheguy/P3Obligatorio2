using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProvEventos.Models
{
    public class ProvEventosContext : DbContext
    {
        public ProvEventosContext() : base("name=ProvEventos")
        {

        }

        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<Servicio> Servicios { get; set; }
        public DbSet<Tipo_Evento> Eventos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Proveedor_VIP> ProveedoresVIP { get; set; }
        public DbSet<Proveedor_Comun> ProveedoresComun { get; set; }
        public DbSet<Rol> Roles { get; set; }
    }
}