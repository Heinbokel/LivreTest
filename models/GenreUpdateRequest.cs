using System.ComponentModel.DataAnnotations;

namespace LivreTest.models {

    public class GenreUpdateRequest {

        [Required]
        [MaxLength(40, ErrorMessage = "Name must be 40 characters or less.")]
        [MinLength(1, ErrorMessage = "Name must be 1 character or greater.")]
        public string Name { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Description must be 100 characters or less.")]
        [MinLength(10, ErrorMessage = "Description must be 10 characters or greater.")]
        public string Description { get; set; }

    }

}