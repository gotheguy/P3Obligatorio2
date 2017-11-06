using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProvEventos.Models
{
    [Table("Proveedor")]
    public abstract class Proveedor : Usuario
    {   
        [NotMapped]
        public static double Arancel;

        [Required]
        [Column("rut", Order = 2, TypeName = "varchar")]
        public string Rut { get; set; }

        [Required]
        [StringLength(100)]
        [Column("nombrefantasia", Order = 3, TypeName = "varchar")]
        public string NombreFantasia { get; set; }

        [StringLength(100)]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        [Column("email", Order = 4, TypeName = "varchar")]
        public string Email { get; set; }

        [Required]
        [Phone]
        [Column("telefono", Order = 5, TypeName = "varchar")]
        public string Telefono { get; set; }

        [Column("activo", Order = 6, TypeName = "bit")]
        public bool Activo { get; set; }

        public virtual Usuario Usuario { get; set; }

        public virtual ICollection<Servicio> Servicios { get; set; }
    }
}