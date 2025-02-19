using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission06_Lasson.Models
{
    public class Movie
    {
        [Key]
        [Required]
        public int MovieId { get; set; }

        [ForeignKey("Categories")]
        public int? CategoryId { get; set; }

        public Categories? Categories { get; set; }
        
        [Required]
        public string Title { get; set; }

        [Required]
        public string Year { get; set; }

        public string? Director { get; set; }

        public string? Rating { get; set; }

        [Required]
        public bool Edited { get; set; }
       
        public string? LentTo { get; set; }

        [Required]
        public bool CopiedToPlex { get; set; }
        
        public string? Notes { get; set; }
    }
}
