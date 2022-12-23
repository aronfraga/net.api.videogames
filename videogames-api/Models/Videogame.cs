using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace videogames_api.Models {
    public class Videogame {

        public Videogame() {
            this.Genres = new HashSet<Genre>();
            this.Platforms = new HashSet<Platform>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdVideogame { get; set; }
        
        public string Name { get; set; } = null!;
        
        public string? Description { get; set; }
        
        public string? ReleaseDate { get; set; }
        
        public string? Image { get; set; }
        
        public int? Rating { get; set; }

        public virtual ICollection<Genre> Genres { get; set; }

        public virtual ICollection<Platform> Platforms { get; set; }

    }
}
