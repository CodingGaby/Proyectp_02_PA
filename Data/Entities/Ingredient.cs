using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Proyectp_02_PA.Data.Entities
{
    public class Ingredient
    {
        #region Props

        public int Id { get; set; }

        [Required]
        [Display(Name = "Nombre")]
        [MaxLength(50, ErrorMessage = "El campo {0} puede tener máximo {1} caracteres")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Calorias")]
        [MaxLength(256, ErrorMessage = "El campo {0} puede tener máximo {1} caracteres")]
        public string? Calories { get; set; }

        [AllowNull]
        public ICollection<RecipeDetail> Recipes { get; set; }

        #endregion
    }
}