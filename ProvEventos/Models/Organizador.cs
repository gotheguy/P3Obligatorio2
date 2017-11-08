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
        [StringLength(100)]
        [Column("NombreOrganizador", Order = 2, TypeName = "varchar")]
        public string NombreOrganizador { get; set; }

        [Required]
        [StringLength(100)]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        [Column("Email", Order = 3, TypeName = "varchar")]
        public string Email { get; set; }

        [Phone]
        [Column("Telefono", Order = 4, TypeName = "varchar")]
        public string Telefono { get; set; }

        [ForeignKey("IdUsuario")]
        [Column("IdUsuario", Order = 5, TypeName = "int")]
        public virtual Usuario Usuario { get; set; }
    }
}