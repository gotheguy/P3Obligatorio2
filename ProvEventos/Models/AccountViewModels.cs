using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProvEventos.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }   
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Remember this browser?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [StringLength(100, ErrorMessage = "El email no puede ser mayor a 100 caracteres")]
        [DataType(DataType.EmailAddress)]
        [DisplayName("Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "La contraseña no puede estar vacía")]
        [DataType(DataType.Password)]
        [DisplayName("Contraseña")]
        [MinLength(8, ErrorMessage = "Largo mínimo de la contraseña: 8"),
        MaxLength(12, ErrorMessage = "Largo máximo de la contraseña:12")]
        public string Clave { get; set; }

        [Display(Name = "Recordarme?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required]
        [StringLength(100, ErrorMessage = "El nombre no puede ser mayor a 100 caracteres")]
        [DisplayName("Nombre")]
        public string NombreOrganizador { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "El email no puede ser mayor a 100 caracteres")]
        [DataType(DataType.EmailAddress)]
        [DisplayName("Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [DisplayName("Teléfono")]
        [RegularExpression(@"^([0-9]{9})$", ErrorMessage = "Teléfono inválido")]
        public string Numero { get; set; }

        [Required(ErrorMessage = "La contraseña no puede estar vacía")]
        [DataType(DataType.Password)]
        [DisplayName("Contraseña")]
        [MinLength(8, ErrorMessage = "Largo mínimo de la contraseña: 8"),
        MaxLength(12, ErrorMessage = "Largo máximo de la contraseña:12")]
        public string Clave { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar contraseña")]
        [Compare("Clave", ErrorMessage = "La contraseña y la confirmación no coinciden")]
        public string ConfirmarClave { get; set; }
    }

    public class ResetPasswordViewModel
    {
        [Required]
        [StringLength(100, ErrorMessage = "El email no puede ser mayor a 100 caracteres")]
        [DataType(DataType.EmailAddress)]
        [DisplayName("Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "La contraseña no puede estar vacía")]
        [DataType(DataType.Password)]
        [DisplayName("Contraseña")]
        [MinLength(8, ErrorMessage = "Largo mínimo de la contraseña: 8"),
        MaxLength(12, ErrorMessage = "Largo máximo de la contraseña:12")]
        public string Clave { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar contraseña")]
        [Compare("Clave", ErrorMessage = "La contraseña y la confirmación no coinciden")]
        public string ConfirmarClave { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
