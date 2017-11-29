using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProvEventos.Models
{
    [Table("Calificacion")]
    public class Calificacion
    {
        [Required]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity), Key()]
        [Column("CalificacionID", Order = 1, TypeName = "int")]
        public int CalificacionID { get; set; }

        [Required(ErrorMessage = "Debe ingresar una calificación")]
        [DisplayName("Estrellas")]
        [Range(1, 5, ErrorMessage = "El puntaje debe ser entre 1 y 5")]
        [Column("Estrellas", Order = 2, TypeName = "int")]
        public int Estrellas { get; set; }

        [DisplayName("Comentario")]
        [StringLength(200, ErrorMessage = "El comentario debe tener menos de 200 caracteres")]
        [Column("Comentario", Order = 3, TypeName = "varchar")]
        public string Comentario { get; set; }

        public virtual Proveedor Proveedor { get; set; }
    }
}