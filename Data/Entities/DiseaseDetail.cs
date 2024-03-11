using System.ComponentModel.DataAnnotations;

namespace Proyectp_02_PA.Data.Entities
{
    public class DiseaseDetail
    {
        #region Props

        public int Id { get; set; }

        [Required]
        public Recipe? Recipe { get; set; }

        [Required]
        public Disease? Disease { get; set; }

        #endregion
    }
}