using System.ComponentModel.DataAnnotations;

namespace Proyectp_02_PA.Data.Entities
{
    public class Recipe
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
        [Display(Name = "Ingredientes")]
        public ICollection<RecipeDetail>? RecipeDetails{ get; set;}

        [Required]
        [Display(Name = "Enfermedades a tomar en cuenta")]
        public ICollection<DiseaseDetail>? DiseaseDetails  { get; set; }


        #endregion
    }
}
