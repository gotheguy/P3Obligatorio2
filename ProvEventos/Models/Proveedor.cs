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
        public static double Arancel;

        [Key, ForeignKey("Usuario")]
        [Required]
        [Column("rut", Order = 1, TypeName = "integer")]
        public int Rut { get; set; }

        [Required]
        [StringLength(100)]
        [Column("nombrefantasia", Order = 2, TypeName = "varchar")]
        public string NombreFantasia { get; set; }

        [StringLength(100)]
        [Column("email", Order = 3, TypeName = "varchar")]
        public string Email { get; set; }

        public string Telefono { get; set; }

        [Column("activo", Order = 4, TypeName = "bit")]
        public bool Activo { get; set; }

      
        public virtual ICollection<Servicio> Servicios { get; set; }
    }
}