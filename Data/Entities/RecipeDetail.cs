using System.ComponentModel.DataAnnotations;

namespace Proyectp_02_PA.Data.Entities
{
    public class RecipeDetail
    {
        #region Props

        public int Id { get; set; }

        [Required]
        public Recipe? Recipe{ get; set; }

        [Required]
        public Ingredient? Ingredient { get; set; }

        #endregion
    }
}