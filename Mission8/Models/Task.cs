using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Mission8.Models
{
    public class Task
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public DateTime? DueDate { get; set; }

        [Required]
        public int Quadrant { get; set; }

        public int? CategoryId { get; set; }

        [Required]
        public bool Completed { get; set; } = false;

        [ForeignKey("Categories")]
        public int? category_id { get; set; } 
        public Categories? Category { get; set; }
    }
}
