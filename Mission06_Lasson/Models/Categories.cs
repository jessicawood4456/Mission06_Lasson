using System.ComponentModel.DataAnnotations;

namespace Mission06_Lasson.Models
{
    public class Categories
    {
        [Key]
        [Required]
        public int CategoryId { get; set; }

        [Required]
        public string CategoryName { get; set; }

    }
}
