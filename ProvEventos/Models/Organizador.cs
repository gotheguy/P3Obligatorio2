using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace ProvEventos.Models
{
    [Table("Organizador")]
    public class Organizador : Usuario
    {
        [Required]
        [StringLength(100, ErrorMessage = "El nombre no puede ser mayor a 100 caracteres")]
        [DisplayName("Nombre")]
        [Column("NombreOrganizador", Order = 2, TypeName = "varchar")]
        public string NombreOrganizador { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        [DisplayName("Teléfono")]
        [RegularExpression(@"^([0-9]{9})$", ErrorMessage = "Teléfono inválido")]
        [Column("Telefono", Order = 3, TypeName = "varchar")]
        public string Telefono { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "El email no puede ser mayor a 100 caracteres")]
        [DataType(DataType.EmailAddress)]
        [DisplayName("Email")]
        [EmailAddress]
        [Column("Email", Order = 3, TypeName = "varchar")]
        public string Email { get; set; }

        public List<Evento> EventosOrganizados { get; set; }
    }
}