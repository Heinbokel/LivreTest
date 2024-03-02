using System.ComponentModel.DataAnnotations;

namespace LivreTest.models {

    public class Genre {

        public int Id { get; set; }

        [MaxLength(40)]
        public string Name { get; set; }

        [MaxLength(100)]
        public string Description { get; set; }

        public List<Book> Books { get; set; }

    }

}