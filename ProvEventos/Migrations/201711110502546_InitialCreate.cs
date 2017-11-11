namespace ProvEventos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        IdUsuario = c.Int(nullable: false, identity: true),
                        NombreUsuario = c.String(nullable: false, maxLength: 50, unicode: false),
                        Clave = c.String(nullable: false, maxLength: 12, unicode: false),
                        FechaRegistro = c.DateTime(nullable: false, storeType: "date"),
                        Rol = c.Int(nullable: false),
                        Rol_IdRol = c.Int(),
                    })
                .PrimaryKey(t => t.IdUsuario)
                .ForeignKey("dbo.Rol", t => t.Rol_IdRol)
                .Index(t => t.Rol_IdRol);
            
            CreateTable(
                "dbo.Servicio",
                c => new
                    {
                        IdServicio = c.Int(nullable: false, identity: true),
                        NombreServicio = c.String(nullable: false, maxLength: 50, unicode: false),
                        Descripcion = c.String(maxLength: 250, unicode: false),
                        Imagen = c.String(maxLength: 200, unicode: false),
                        Proveedor_IdUsuario = c.Int(),
                    })
                .PrimaryKey(t => t.IdServicio)
                .ForeignKey("dbo.Proveedor", t => t.Proveedor_IdUsuario)
                .Index(t => t.Proveedor_IdUsuario);
            
            CreateTable(
                "dbo.Tipo_Evento",
                c => new
                    {
                        IdTipoEvento = c.Int(nullable: false, identity: true),
                        NombreTipoEvento = c.String(nullable: false, maxLength: 100, unicode: false),
                        Descripcion = c.String(maxLength: 250, unicode: false),
                        Servicio_IdServicio = c.Int(),
                    })
                .PrimaryKey(t => t.IdTipoEvento)
                .ForeignKey("dbo.Servicio", t => t.Servicio_IdServicio)
                .Index(t => t.Servicio_IdServicio);
            
            CreateTable(
                "dbo.Rol",
                c => new
                    {
                        IdRol = c.Int(nullable: false, identity: true),
                        rol = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdRol);
            
            CreateTable(
                "dbo.Administrador",
                c => new
                    {
                        IdUsuario = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdUsuario)
                .ForeignKey("dbo.Usuario", t => t.IdUsuario)
                .Index(t => t.IdUsuario);
            
            CreateTable(
                "dbo.Organizador",
                c => new
                    {
                        IdUsuario = c.Int(nullable: false),
                        NombreOrganizador = c.String(nullable: false, maxLength: 100, unicode: false),
                        Email = c.String(nullable: false, maxLength: 100, unicode: false),
                        Telefono = c.String(maxLength: 8000, unicode: false),
                    })
                .PrimaryKey(t => t.IdUsuario)
                .ForeignKey("dbo.Usuario", t => t.IdUsuario)
                .Index(t => t.IdUsuario);
            
            CreateTable(
                "dbo.Proveedor",
                c => new
                    {
                        IdUsuario = c.Int(nullable: false),
                        Rut = c.Int(nullable: false),
                        NombreFantasia = c.String(nullable: false, maxLength: 100, unicode: false),
                        Email = c.String(maxLength: 100, unicode: false),
                        Telefono = c.String(nullable: false, maxLength: 8000, unicode: false),
                        Activo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.IdUsuario)
                .ForeignKey("dbo.Usuario", t => t.IdUsuario)
                .ForeignKey("dbo.Usuario", t => t.Rut)
                .Index(t => t.IdUsuario)
                .Index(t => t.Rut);
            
            CreateTable(
                "dbo.Proveedor_Comun",
                c => new
                    {
                        IdUsuario = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdUsuario)
                .ForeignKey("dbo.Proveedor", t => t.IdUsuario)
                .Index(t => t.IdUsuario);
            
            CreateTable(
                "dbo.Proveedor_VIP",
                c => new
                    {
                        IdUsuario = c.Int(nullable: false),
                        Porcentaje = c.Double(nullable: false),
                        Proveedor_IdUsuario = c.Int(),
                    })
                .PrimaryKey(t => t.IdUsuario)
                .ForeignKey("dbo.Proveedor", t => t.IdUsuario)
                .ForeignKey("dbo.Proveedor", t => t.Proveedor_IdUsuario)
                .Index(t => t.IdUsuario)
                .Index(t => t.Proveedor_IdUsuario);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Proveedor_VIP", "Proveedor_IdUsuario", "dbo.Proveedor");
            DropForeignKey("dbo.Proveedor_VIP", "IdUsuario", "dbo.Proveedor");
            DropForeignKey("dbo.Proveedor_Comun", "IdUsuario", "dbo.Proveedor");
            DropForeignKey("dbo.Proveedor", "Rut", "dbo.Usuario");
            DropForeignKey("dbo.Proveedor", "IdUsuario", "dbo.Usuario");
            DropForeignKey("dbo.Organizador", "IdUsuario", "dbo.Usuario");
            DropForeignKey("dbo.Administrador", "IdUsuario", "dbo.Usuario");
            DropForeignKey("dbo.Usuario", "Rol_IdRol", "dbo.Rol");
            DropForeignKey("dbo.Servicio", "Proveedor_IdUsuario", "dbo.Proveedor");
            DropForeignKey("dbo.Tipo_Evento", "Servicio_IdServicio", "dbo.Servicio");
            DropIndex("dbo.Proveedor_VIP", new[] { "Proveedor_IdUsuario" });
            DropIndex("dbo.Proveedor_VIP", new[] { "IdUsuario" });
            DropIndex("dbo.Proveedor_Comun", new[] { "IdUsuario" });
            DropIndex("dbo.Proveedor", new[] { "Rut" });
            DropIndex("dbo.Proveedor", new[] { "IdUsuario" });
            DropIndex("dbo.Organizador", new[] { "IdUsuario" });
            DropIndex("dbo.Administrador", new[] { "IdUsuario" });
            DropIndex("dbo.Tipo_Evento", new[] { "Servicio_IdServicio" });
            DropIndex("dbo.Servicio", new[] { "Proveedor_IdUsuario" });
            DropIndex("dbo.Usuario", new[] { "Rol_IdRol" });
            DropTable("dbo.Proveedor_VIP");
            DropTable("dbo.Proveedor_Comun");
            DropTable("dbo.Proveedor");
            DropTable("dbo.Organizador");
            DropTable("dbo.Administrador");
            DropTable("dbo.Rol");
            DropTable("dbo.Tipo_Evento");
            DropTable("dbo.Servicio");
            DropTable("dbo.Usuario");
        }
    }
}
