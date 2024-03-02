using System.ComponentModel.DataAnnotations;

namespace LivreTest.models {

    public class BookImage {

        public int Id { get; set; }

        public string ImageUrl { get; set; }

        [MaxLength(100)]
        public string Caption { get; set; }

        public int BookId {get; set;}
        public Book Book { get; set; }

    }

}