using System.ComponentModel.DataAnnotations;

namespace Proyectp_02_PA.Data.Entities
{
    public class Pantry
    {
        #region Props

        public int Id { get; set; }

        [Required]
        [Display(Name = "Nombre")]
        [MaxLength(50, ErrorMessage = "El campo {0} puede tener máximo {1} caracteres")]
        public string? Name { get; set; }

        [Required]
        [Display(Name = "Descripcion")]
        [MaxLength(256, ErrorMessage = "El campo {0} puede tener máximo {1} caracteres")]
        public string? Descripcion { get; set; }

        [Required]
        public User? User { get; set; }

        [Required]
        [Display(Name = "Ingredientes")]
        public ICollection<Ingredient>? Ingredients { get; set; }

        #endregion
    }
}
