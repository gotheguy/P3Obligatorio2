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
        [Key]
        [Required]
        [Column("ID", Order = 1, TypeName = "int")]
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        [Column("Nombre", Order = 2, TypeName = "varchar")]
        public string Nombre { get; set; }

        [StringLength(250)]
        [Column("Descripcion", Order = 3, TypeName = "varchar")]
        public string Descripcion { get; set; }

        [StringLength(200)]
        [Column("Imagen", Order = 4, TypeName = "varchar")]
        public string Imagen { get; set; }

        public virtual Proveedor Proveedor { get; set; }

        public virtual ICollection<Tipo_Evento> Eventos { get; set; }
    }
}