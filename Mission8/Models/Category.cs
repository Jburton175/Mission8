using System.ComponentModel.DataAnnotations;

namespace Mission8.Models
{
    public class Categories
    {
        [Key]
        public int category_id { get; set; }
        public string category_name { get; set; }
    }
}
