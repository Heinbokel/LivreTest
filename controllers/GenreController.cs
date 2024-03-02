using LivreTest.models;
using LivreTest.repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LivreTest.controllers {

    [ApiController]
    public class GenreController: ControllerBase {

        private readonly LivreDbContext _context;

        public GenreController(LivreDbContext livreDbContext) {
            this._context = livreDbContext;
        }

        [HttpGet("genres", Name = "GetGenres")]
        public List<Genre> GetGenres([FromQuery] string? criteria) {
            if (criteria != null) {
                return this._context.Genres
                    .Include(genres => genres.Books)
                    .Where(genres => genres.Name.ToUpper().Contains(criteria.ToUpper()))
                    .ToList();
            } else {
                return this._context.Genres
                .Include(genres => genres.Books)
                .ToList();
            }
            
        }

        [HttpGet("genres/{genreId}", Name = "GetGenreByGenreId")]
        public Genre? GetGenreByGenreId(int genreId) {
            return this._context.Genres
                .Where(genre => genre.Id == genreId)
                .Include(genre => genre.Books)
                .FirstOrDefault();
        }

        [HttpPost("genres", Name = "CreateGenre")]
        public Genre CreateGenre([FromBody] GenreCreateRequest request) {
            Genre genre = new Genre
            {
                Name = request.Name,
                Description = request.Description
            };

            this._context.Genres.Add(genre);
            this._context.SaveChanges();

            return genre;
        }

        [HttpPut("genres/{genreId}", Name = "UpdateGenre")]
        public void UpdateGenre([FromBody] GenreUpdateRequest request, int genreId) {
            Genre? genreToUpdate = this._context.Genres
                .Find(genreId); // Finds our entity by its primary key.

            if (genreToUpdate != null) {
                genreToUpdate.Name = request.Name;
                genreToUpdate.Description = request.Description;

                this._context.SaveChanges();
            } else {
                throw new Exception($"Could not find genre with ID {genreId}, unable to update genre.");
            }
        }

        [HttpDelete("genres/{genreId}", Name = "DeleteGenre")]
        public void DeleteGenre(int genreId) {
            Genre? genreToDelete = this._context.Genres
                .Find(genreId); // Finds our entity by its primary key.

            if (genreToDelete != null) {
                this._context.Genres.Remove(genreToDelete);

                this._context.SaveChanges();
            } else {
                throw new Exception($"Could not find genre with ID {genreId}, unable to delete genre.");
            }
        }
        

    }

}