using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace LivreTest.models {

    public class Book {

        public int Id { get; set; }
        
        [MaxLength(150)]
        public string Title { get; set; }

        [MaxLength(255)]
        public string? Synopsis { get; set; }
        public DateOnly PublicationDate { get; set; }

        [MaxLength(13)]
        public string Isbn { get; set; }

        [JsonIgnore]
        public List<Genre> Genres { get; set; }
        public List<Author> Authors { get; set; }
        public List<BookImage> BookImages { get; set; }

    }

}