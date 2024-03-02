using System.ComponentModel.DataAnnotations;

namespace LivreTest.models {

    public class Author {

        public int Id { get; set; }

        [MaxLength(50)]
        public string FirstName { get; set; }

        [MaxLength(50)]
        public string? MiddleName { get; set; }

        [MaxLength(50)]
        public string LastName { get; set; }

        [MaxLength(500)]
        public string Biography { get; set; }

        [MaxLength(50)]
        public string Nationality { get; set; }

        public List<Book> Books { get; set; }

    }

}