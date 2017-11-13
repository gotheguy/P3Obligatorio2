using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProvEventos.Models
{
    [Table("Organizador")]
    public class Organizador : Usuario
    {
        [Required]
        [StringLength(100, ErrorMessage = "El nombre no puede ser mayor a 100 caracteres")]
        [Column("NombreOrganizador", Order = 2, TypeName = "varchar")]
        public string NombreOrganizador { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "El email no puede ser mayor a 100 caracteres")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        [Column("Email", Order = 3, TypeName = "varchar")]
        public string Email { get; set; }

        [ForeignKey("UsuarioID"), Key]
        [Column("UsuarioID", Order = 5, TypeName = "int")]
        public virtual Usuario Usuario { get; set; }

        public virtual ICollection<Telefono> Telefonos { get; set; }
    }
}