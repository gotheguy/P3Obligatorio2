using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ProvEventos.Models
{
    public enum Roles
    {
        Administrador,
        Organizador,
        Proveedor
    }

    [Table("Rol")]
    public class Rol
    {
        [Key]
        [Required]
        [Column("RolID", Order = 1, TypeName = "int")]
        public int RolID { get; set; }
            
        [Column("Rol", Order = 2)]
        public string RolString
        {
            get { return Roles.ToString(); }
            private set { Roles = value.ParseEnum<Roles>(); }
        }

        [NotMapped]
        public Roles Roles { get; set; }
    }
    public static class StringExtensions
    {
        public static T ParseEnum<T>(this string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }
    }
}