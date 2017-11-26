namespace ProvEventos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initcreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        Email = c.String(maxLength: 100, unicode: false),
                        UsuarioID = c.Int(nullable: false, identity: true),
                        NombreUsuario = c.String(nullable: false, maxLength: 50),
                        Clave = c.String(nullable: false, maxLength: 12),
                        FechaRegistro = c.DateTime(nullable: false),
                        RolID = c.Int(nullable: false),
                        //EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        //SecurityStamp = c.String(),
                        //PhoneNumber = c.String(),
                        //PhoneNumberConfirmed = c.Boolean(nullable: false),
                        //TwoFactorEnabled = c.Boolean(nullable: false),
                        //LockoutEndDateUtc = c.DateTime(),
                        //LockoutEnabled = c.Boolean(nullable: false),
                        //AccessFailedCount = c.Int(nullable: false),
                        Id = c.String(),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.UsuarioID)
                .ForeignKey("dbo.Rol", t => t.RolID, cascadeDelete: true)
                .Index(t => t.RolID);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        Usuario_UsuarioID = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Usuario", t => t.Usuario_UsuarioID)
                .Index(t => t.Usuario_UsuarioID);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        Usuario_UsuarioID = c.Int(),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Usuario", t => t.Usuario_UsuarioID)
                .Index(t => t.Usuario_UsuarioID);
            
            CreateTable(
                "dbo.Rol",
                c => new
                    {
                        RolID = c.Int(nullable: false, identity: true),
                        Rol = c.String(),
                    })
                .PrimaryKey(t => t.RolID);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        RoleId = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                        Usuario_UsuarioID = c.Int(),
                        IdentityRole_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.RoleId, t.UserId })
                .ForeignKey("dbo.Usuario", t => t.Usuario_UsuarioID)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .Index(t => t.Usuario_UsuarioID)
                .Index(t => t.IdentityRole_Id);
            
            CreateTable(
                "dbo.Evento",
                c => new
                    {
                        EventoID = c.Int(nullable: false, identity: true),
                        Direccion = c.String(nullable: false, maxLength: 100, unicode: false),
                        FechaEvento = c.DateTime(nullable: false, storeType: "date"),
                        Tipo_TipoEventoID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EventoID)
                .ForeignKey("dbo.Tipo_Evento", t => t.Tipo_TipoEventoID, cascadeDelete: true)
                .Index(t => t.Tipo_TipoEventoID);
            
            CreateTable(
                "dbo.Servicio",
                c => new
                    {
                        ServicioID = c.Int(nullable: false, identity: true),
                        NombreServicio = c.String(nullable: false, maxLength: 50, unicode: false),
                        Descripcion = c.String(maxLength: 250, unicode: false),
                        Imagen = c.String(maxLength: 200, unicode: false),
                        Evento_EventoID = c.Int(),
                    })
                .PrimaryKey(t => t.ServicioID)
                .ForeignKey("dbo.Evento", t => t.Evento_EventoID)
                .Index(t => t.Evento_EventoID);
            
            CreateTable(
                "dbo.Tipo_Evento",
                c => new
                    {
                        TipoEventoID = c.Int(nullable: false, identity: true),
                        NombreTipoEvento = c.String(nullable: false, maxLength: 100, unicode: false),
                        Descripcion = c.String(maxLength: 250, unicode: false),
                    })
                .PrimaryKey(t => t.TipoEventoID);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProveedorServicio",
                c => new
                    {
                        Proveedor_UsuarioID = c.Int(nullable: false),
                        Servicio_ServicioID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Proveedor_UsuarioID, t.Servicio_ServicioID })
                .ForeignKey("dbo.Proveedor", t => t.Proveedor_UsuarioID, cascadeDelete: true)
                .ForeignKey("dbo.Servicio", t => t.Servicio_ServicioID, cascadeDelete: true)
                .Index(t => t.Proveedor_UsuarioID)
                .Index(t => t.Servicio_ServicioID);
            
            CreateTable(
                "dbo.Tipo_EventoServicio",
                c => new
                    {
                        Tipo_Evento_TipoEventoID = c.Int(nullable: false),
                        Servicio_ServicioID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Tipo_Evento_TipoEventoID, t.Servicio_ServicioID })
                .ForeignKey("dbo.Tipo_Evento", t => t.Tipo_Evento_TipoEventoID, cascadeDelete: true)
                .ForeignKey("dbo.Servicio", t => t.Servicio_ServicioID, cascadeDelete: true)
                .Index(t => t.Tipo_Evento_TipoEventoID)
                .Index(t => t.Servicio_ServicioID);
            
            CreateTable(
                "dbo.Administrador",
                c => new
                    {
                        UsuarioID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UsuarioID)
                .ForeignKey("dbo.Usuario", t => t.UsuarioID)
                .Index(t => t.UsuarioID);
            
            CreateTable(
                "dbo.Organizador",
                c => new
                    {
                        NombreOrganizador = c.String(nullable: false, maxLength: 100, unicode: false),
                        Telefono = c.String(nullable: false, maxLength: 8000, unicode: false),
                        UsuarioID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UsuarioID)
                .ForeignKey("dbo.Usuario", t => t.UsuarioID)
                .Index(t => t.UsuarioID);
            
            CreateTable(
                "dbo.Proveedor",
                c => new
                    {
                        Rut = c.String(nullable: false, maxLength: 8000, unicode: false),
                        NombreFantasia = c.String(nullable: false, maxLength: 100, unicode: false),
                        Telefono = c.String(nullable: false, maxLength: 8000, unicode: false),
                        Activo = c.Boolean(nullable: false),
                        VIP = c.Boolean(nullable: false),
                        UsuarioID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UsuarioID)
                .ForeignKey("dbo.Usuario", t => t.UsuarioID)
                .Index(t => t.UsuarioID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Proveedor", "UsuarioID", "dbo.Usuario");
            DropForeignKey("dbo.Organizador", "UsuarioID", "dbo.Usuario");
            DropForeignKey("dbo.Administrador", "UsuarioID", "dbo.Usuario");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.IdentityUserRole", "Usuario_UsuarioID", "dbo.Usuario");
            DropForeignKey("dbo.Usuario", "RolID", "dbo.Rol");
            DropForeignKey("dbo.IdentityUserLogin", "Usuario_UsuarioID", "dbo.Usuario");
            DropForeignKey("dbo.IdentityUserClaim", "Usuario_UsuarioID", "dbo.Usuario");
            DropForeignKey("dbo.Evento", "Tipo_TipoEventoID", "dbo.Tipo_Evento");
            DropForeignKey("dbo.Servicio", "Evento_EventoID", "dbo.Evento");
            DropForeignKey("dbo.Tipo_EventoServicio", "Servicio_ServicioID", "dbo.Servicio");
            DropForeignKey("dbo.Tipo_EventoServicio", "Tipo_Evento_TipoEventoID", "dbo.Tipo_Evento");
            DropForeignKey("dbo.ProveedorServicio", "Servicio_ServicioID", "dbo.Servicio");
            DropForeignKey("dbo.ProveedorServicio", "Proveedor_UsuarioID", "dbo.Proveedor");
            DropIndex("dbo.Proveedor", new[] { "UsuarioID" });
            DropIndex("dbo.Organizador", new[] { "UsuarioID" });
            DropIndex("dbo.Administrador", new[] { "UsuarioID" });
            DropIndex("dbo.Tipo_EventoServicio", new[] { "Servicio_ServicioID" });
            DropIndex("dbo.Tipo_EventoServicio", new[] { "Tipo_Evento_TipoEventoID" });
            DropIndex("dbo.ProveedorServicio", new[] { "Servicio_ServicioID" });
            DropIndex("dbo.ProveedorServicio", new[] { "Proveedor_UsuarioID" });
            DropIndex("dbo.Servicio", new[] { "Evento_EventoID" });
            DropIndex("dbo.Evento", new[] { "Tipo_TipoEventoID" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "Usuario_UsuarioID" });
            DropIndex("dbo.IdentityUserLogin", new[] { "Usuario_UsuarioID" });
            DropIndex("dbo.IdentityUserClaim", new[] { "Usuario_UsuarioID" });
            DropIndex("dbo.Usuario", new[] { "RolID" });
            DropTable("dbo.Proveedor");
            DropTable("dbo.Organizador");
            DropTable("dbo.Administrador");
            DropTable("dbo.Tipo_EventoServicio");
            DropTable("dbo.ProveedorServicio");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.Tipo_Evento");
            DropTable("dbo.Servicio");
            DropTable("dbo.Evento");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.Rol");
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.Usuario");
        }
    }
}
