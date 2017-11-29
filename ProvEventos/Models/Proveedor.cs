using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace ProvEventos.Models
{
    [Table("Proveedor")]
    public class Proveedor : Usuario
    {   
        [Required(ErrorMessage = "El RUT no puede estar vacío")]
        [Column("Rut", Order = 2, TypeName = "varchar")]
        public string Rut { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "El nombre de fantasía no puede ser mayor a 100 caracteres")]
        [Column("NombreFantasia", Order = 3, TypeName = "varchar")]
        public string NombreFantasia { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [DisplayName("Teléfono")]
        [RegularExpression(@"^([0-9]{9})$", ErrorMessage = "Teléfono inválido")]
        [Column("Telefono", Order = 4, TypeName = "varchar")]
        public string Telefono { get; set; }

        [Column("Activo", Order = 5, TypeName = "bit")]
        public bool Activo { get; set; }

        [Column("VIP", Order = 6, TypeName = "bit")]
        public bool VIP { get; set; }

        public virtual Evento Evento { get; set; }

        public virtual ICollection<Servicio> Servicios { get; set; }

        public virtual ICollection<Calificacion> Calificaciones { get; set; }
    }
}