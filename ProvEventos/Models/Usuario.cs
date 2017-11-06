﻿using System;
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
        [Required]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity), Key()]
        [Column("ID", Order = 1, TypeName = "int")]
        public int ID { get; set; }

        [Required(ErrorMessage = "El nombre no puede estar vacío")]
        [DisplayName("Nombre de usuario")]
        [StringLength(30)]
        [Column("Nombre", Order = 2, TypeName = "varchar")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La contraseña no puede estar vacía")]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage = "Largo mínimo de la contraseña: 8"),
        MaxLength(12, ErrorMessage = "Largo máximo de la contraseña:12")]
        [Column("Clave", Order = 3, TypeName = "varchar")]
        public string Clave { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Column("FechaRegistro", Order = 4, TypeName = "datetime")]
        public DateTime FechaRegistro { get; set; }

        [Required]
        public virtual Rol.Tipo Rol { get; set; }
    }
}