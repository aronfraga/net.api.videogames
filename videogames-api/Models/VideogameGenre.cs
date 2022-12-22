namespace videogames_api.Models {
    public class VideogameGenre {
        public int IdVideogame { get; set; }

        public int IdGenre { get; set; }

        public Videogame Videogame { get; set; }

        public Genre Genre { get; set; }
    }
}
