using System.ComponentModel.DataAnnotations;

using System.ComponentModel.DataAnnotations.Schema;


namespace Mission6_Stanford.Models
{
    public class Movie
    {
        [Key]
        public int MovieId { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string CategoryID { get; set; } = string.Empty;

        [Required]
        [Range(1888, 2100, ErrorMessage = "Year must be between 1888 and 2100.")]
        public int Year { get; set; } 

        [Required]
        public string? Director { get; set; }

        [Required]
        public string Rating { get; set; } = string.Empty;

        public bool Edited { get; set; } = false;
        public string? LentTo { get; set; }
        [MaxLength(25)]
        public string? Notes { get; set; }
        [Required]
        public bool CopiedToPlex { get; set; }
    }
}