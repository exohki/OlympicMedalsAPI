using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OlympicMedalsAPI.Models
{
    public class Country
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        public int Gold { get; set; } = 0;
        public int Silver { get; set; } = 0;
        public int Bronze { get; set; } = 0;
    }
}
