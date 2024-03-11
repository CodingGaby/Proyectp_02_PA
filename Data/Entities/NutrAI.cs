using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Proyectp_02_PA.Data.Entities
{
    public class NutrAI
    {
        #region Props

        public int Id { get; set; }
        
        [AllowNull]
        [Display(Name = "Recetas")]
        public ICollection<Recipe>? Recipes{ get; set; }

        #endregion
    }
}
