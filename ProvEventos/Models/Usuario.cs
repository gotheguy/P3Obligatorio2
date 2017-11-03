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
    public class Usuario
    {
        [Key]
        [Required(ErrorMessage = "El nombre no puede estar vacío")]
        [DisplayName("Nombre de usuario")]
        [StringLength(30)]
        public string NombreUsuario { get; set; }

        [Required(ErrorMessage = "La contraseña no puede estar vacía")]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage = "Largo mínimo de la contraseña: 8"),
        MaxLength(12, ErrorMessage = "Largo máximo de la contraseña:12")]
        public string Clave { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime FechaRegistro { get; set; }

        [ForeignKey("Rol")]
        public virtual Rol.Roles Rol { get; set; }
    }
}