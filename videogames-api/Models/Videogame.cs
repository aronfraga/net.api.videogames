using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace videogames_api.Models {
    public class Videogame {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdVideogame { get; set; }
        
        public string Name { get; set; } = null!;
        
        public string? Description { get; set; }
        
        public string? ReleaseDate { get; set; }
        
        public string? Image { get; set; }
        
        public int? Rating { get; set; }

        public int IdPlatform { get; set; }

        public int IdGenre { get; set; }

        [ForeignKey("IdPlatform")]
        public virtual ICollection<Platform> Platform { get; set; }

        [ForeignKey("IdGenre")]
        public virtual ICollection<Genre> Genre { get; set; }
    }
}
