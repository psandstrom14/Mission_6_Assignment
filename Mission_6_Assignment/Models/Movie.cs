
using System.ComponentModel.DataAnnotations;

namespace Mission_6_Assignment.Models
    {
        public class Movie
        {
            [Key]
            [Required]
            public int MovieId { get; set; }

            [Required]
            public int CategoryId { get; set; }
            public Category? Category { get; set; }
        
            [Required]
            public string? Title { get; set; }

            [Required]
            public int? Year { get; set; }

          
            public string? Director { get; set; }

            public string? Rating { get; set; }

            public bool Edited { get; set; }

            public string? LentTo { get; set; }

            public bool CopiedToPlex { get; set; }

            [MaxLength(25)]
            public string? Notes { get; set; }
        }
    }
