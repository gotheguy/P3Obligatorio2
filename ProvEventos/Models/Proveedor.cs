using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProvEventos.Models
{
    [Table("Proveedor")]
    public class Proveedor : Usuario
    {   
        [NotMapped]
        public static double Arancel;

        [Required(ErrorMessage = "El RUT no puede estar vacío")]
        [Column("Rut", Order = 2, TypeName = "varchar")]
        public string Rut { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "El nombre de fantasía no puede ser mayor a 100 caracteres")]
        [Column("NombreFantasia", Order = 3, TypeName = "varchar")]
        public string NombreFantasia { get; set; }

        [StringLength(100, ErrorMessage = "El email no puede ser mayor a 100 caracteres")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        [Column("Email", Order = 4, TypeName = "varchar")]
        public string Email { get; set; }

        [Column("Activo", Order = 6, TypeName = "bit")]
        public bool Activo { get; set; }

        [ForeignKey("UsuarioID"),Key]
        [Column("UsuarioID", Order = 7, TypeName = "int")]
        public virtual Usuario Usuario { get; set; }

        public virtual ICollection<Telefono> Telefonos { get; set; }

        public virtual ICollection<Servicio> Servicios { get; set; }
    }
}