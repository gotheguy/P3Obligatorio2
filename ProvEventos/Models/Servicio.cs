using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProvEventos.Models
{
    [Table("Servicio")]
    public class Servicio
    {
        [Required]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity), Key()]
        [Column("IdServicio", Order = 1, TypeName = "int")]
        public int IdServicio { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "El nombre no puede ser mayor a 50 caracteres")]
        [Column("NombreServicio", Order = 2, TypeName = "varchar")]
        public string NombreServicio { get; set; }

        [StringLength(250, ErrorMessage = "La descripción no puede ser mayor a 250 caracteres")]
        [Column("Descripcion", Order = 3, TypeName = "varchar")]
        public string Descripcion { get; set; }

        [StringLength(200)]
        [Column("Imagen", Order = 4, TypeName = "varchar")]
        public string Imagen { get; set; }

        public virtual Proveedor Proveedor { get; set; }
        public virtual ICollection<Tipo_Evento> Eventos { get; set; }
    }
}