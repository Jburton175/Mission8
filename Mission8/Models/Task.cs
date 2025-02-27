using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Mission8.Models
{
    public class Task
    {
        [Key]
        public int TaskId { get; set; }

        [Required]
        public string name { get; set; }

        public DateTime? due_date { get; set; }

        [Required]
        public int quadrant { get; set; }


        [Required]
        public bool completed { get; set; } = false;

        [ForeignKey("Categories")]
        public int? category_id { get; set; } 
        public Categories? Category { get; set; }
    }
}
