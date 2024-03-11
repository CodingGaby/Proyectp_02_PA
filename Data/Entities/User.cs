using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Proyectp_02_PA.Data.Entities
{
    public class User : IdentityUser
    {
        #region Props

        [Required]
        [Display(Name = "Nombre(s)")]
        [MaxLength(50, ErrorMessage = "El campo {0} puede tener máximo {1} caracteres")]
        public string? FirstName { get; set; }

        [Required]
        [Display(Name = "Apellidos")]
        [MaxLength(100, ErrorMessage = "El campo {0} puede tener máximo {1} caracteres")]
        public string? LastName { get; set; }

        [Required]
        [Display(Name = "Numero Celular")]
        [MaxLength(20, ErrorMessage = "El campo {0} puede tener máximo {1} caracteres")]
        public override string? PhoneNumber { get => base.PhoneNumber; set => base.PhoneNumber = value; }

        [Required]
        [Display(Name = "Peso")]
        public double? Weight { get; set; }

        [Required]
        [Display(Name = "Altura")]
        public double? Height { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "Cumpleaños")]
        public DateTime? BirthDate { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Correo electronico")]
        public override string? Email { get; set; }

        [Display(Name = "Actividades diarias")]
        [AllowNull]
        public ICollection<DailyActivity>? DailyActivities { get; set; }

        [Display(Name = "Enfermedades")]
        [AllowNull]
        public ICollection<Disease> Diseases { get; set; }

        [Required]
        [Display(Name = "Contraseña")]
        [DataType(DataType.Password)]
        public string? Password{ get; set; }

        #endregion
    }
}
