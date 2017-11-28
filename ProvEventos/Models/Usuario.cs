using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace ProvEventos.Models
{
    [Table("Usuario")]
    public class Usuario : ApplicationUser
    {
        [Required]
        [DataType(DataType.Date)]
        [DisplayName("Fecha de registro")]
        [DisplayFormat(DataFormatString = "{0: dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Column("FechaRegistro", Order = 2, TypeName = "date")]
        public DateTime FechaRegistro { get; set; }

        public int RolID { get; set; }
        public virtual Rol Rol { get; set; }
    }
}