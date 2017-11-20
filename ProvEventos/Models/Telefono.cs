using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProvEventos.Models
{
    [Table("Telefono")]
    public class Telefono
    {
        [Required]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity), Key()]
        [Column("TelefonoID", Order = 1, TypeName = "int")]
        public int TelefonoID { get; set; }

        [Required]
        //[RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Teléfono inválido")]
        [Column("Numero", Order = 2, TypeName = "varchar")]
        public string Numero { get; set; }

        [Required]
        public int UsuarioID { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}