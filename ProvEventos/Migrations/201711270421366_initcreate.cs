namespace ProvEventos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initcreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        Id = c.Int(nullable: false),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.Rol",
                c => new
                    {
                        RolID = c.Int(nullable: false, identity: true),
                        Rol = c.String(),
                    })
                .PrimaryKey(t => t.RolID);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        RoleId = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.RoleId, t.UserId })
                .ForeignKey("dbo.AspNetRoles", t => t.IdentityRole_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
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
                "dbo.AspNetRoles",
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
                        Proveedor_Id = c.String(nullable: false, maxLength: 128),
                        Servicio_ServicioID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Proveedor_Id, t.Servicio_ServicioID })
                .ForeignKey("dbo.Proveedor", t => t.Proveedor_Id, cascadeDelete: true)
                .ForeignKey("dbo.Servicio", t => t.Servicio_ServicioID, cascadeDelete: true)
                .Index(t => t.Proveedor_Id)
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
                "dbo.Usuario",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FechaRegistro = c.DateTime(nullable: false),
                        RolID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Id)
                .ForeignKey("dbo.Rol", t => t.RolID, cascadeDelete: true)
                .Index(t => t.Id)
                .Index(t => t.RolID);
            
            CreateTable(
                "dbo.Administrador",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Usuario", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Organizador",
                c => new
                    {
                        NombreOrganizador = c.String(nullable: false, maxLength: 100, unicode: false),
                        Telefono = c.String(nullable: false, maxLength: 8000, unicode: false),
                        Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Usuario", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Proveedor",
                c => new
                    {
                        Rut = c.String(nullable: false, maxLength: 8000, unicode: false),
                        NombreFantasia = c.String(nullable: false, maxLength: 100, unicode: false),
                        Telefono = c.String(nullable: false, maxLength: 8000, unicode: false),
                        Activo = c.Boolean(nullable: false),
                        VIP = c.Boolean(nullable: false),
                        Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Usuario", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Proveedor", "Id", "dbo.Usuario");
            DropForeignKey("dbo.Organizador", "Id", "dbo.Usuario");
            DropForeignKey("dbo.Administrador", "Id", "dbo.Usuario");
            DropForeignKey("dbo.Usuario", "RolID", "dbo.Rol");
            DropForeignKey("dbo.Usuario", "Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "IdentityRole_Id", "dbo.AspNetRoles");
            DropForeignKey("dbo.Evento", "Tipo_TipoEventoID", "dbo.Tipo_Evento");
            DropForeignKey("dbo.Servicio", "Evento_EventoID", "dbo.Evento");
            DropForeignKey("dbo.Tipo_EventoServicio", "Servicio_ServicioID", "dbo.Servicio");
            DropForeignKey("dbo.Tipo_EventoServicio", "Tipo_Evento_TipoEventoID", "dbo.Tipo_Evento");
            DropForeignKey("dbo.ProveedorServicio", "Servicio_ServicioID", "dbo.Servicio");
            DropForeignKey("dbo.ProveedorServicio", "Proveedor_Id", "dbo.Proveedor");
            DropIndex("dbo.Proveedor", new[] { "Id" });
            DropIndex("dbo.Organizador", new[] { "Id" });
            DropIndex("dbo.Administrador", new[] { "Id" });
            DropIndex("dbo.Usuario", new[] { "RolID" });
            DropIndex("dbo.Usuario", new[] { "Id" });
            DropIndex("dbo.Tipo_EventoServicio", new[] { "Servicio_ServicioID" });
            DropIndex("dbo.Tipo_EventoServicio", new[] { "Tipo_Evento_TipoEventoID" });
            DropIndex("dbo.ProveedorServicio", new[] { "Servicio_ServicioID" });
            DropIndex("dbo.ProveedorServicio", new[] { "Proveedor_Id" });
            DropIndex("dbo.Servicio", new[] { "Evento_EventoID" });
            DropIndex("dbo.Evento", new[] { "Tipo_TipoEventoID" });
            DropIndex("dbo.AspNetUserRoles", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "IdentityRole_Id" });
            DropIndex("dbo.AspNetUserLogins", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.AspNetUserClaims", new[] { "ApplicationUser_Id" });
            DropTable("dbo.Proveedor");
            DropTable("dbo.Organizador");
            DropTable("dbo.Administrador");
            DropTable("dbo.Usuario");
            DropTable("dbo.Tipo_EventoServicio");
            DropTable("dbo.ProveedorServicio");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Tipo_Evento");
            DropTable("dbo.Servicio");
            DropTable("dbo.Evento");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.Rol");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
        }
    }
}
