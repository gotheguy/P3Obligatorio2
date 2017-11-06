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
        [Column("nombre", Order = 2, TypeName = "varchar")]
        public new string Nombre { get; set; }

        [Required]
        [StringLength(100)]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        [Column("email", Order = 3, TypeName = "varchar")]
        public string Email { get; set; }

        [Phone]
        [Column("telefono", Order = 4, TypeName = "varchar")]
        public string Telefono { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}