using LivreTest.models;
using Microsoft.EntityFrameworkCore;

namespace LivreTest.repositories {

    public class LivreDbContext: DbContext {

        private readonly IConfiguration _configuration;

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<BookImage> BookImages { get; set; }

        public LivreDbContext(IConfiguration configuration) {
            this._configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));

            optionsBuilder.UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()));

            optionsBuilder.EnableDetailedErrors();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Genre>().HasData(
                new Genre {Id = 1, Name = "Fantasy", Description = "Worlds of magic and adventure await."},
                new Genre {Id = 2, Name = "Science Fiction", Description = "Explore futuristic technologies and alien worlds."},
                new Genre {Id = 3, Name = "Mystery", Description = "Unravel puzzles and solve crimes."},
                new Genre {Id = 4, Name = "Romance", Description = "Full of passion and heartache."}
            );
        }

    }

}