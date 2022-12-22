using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace videogames_api.Models {
    public class Genre {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdGenre { get; set; }

        public string Name { get; set; } = null!;

        public virtual ICollection<Videogame>? Videogame { get; set; }
    }
}
