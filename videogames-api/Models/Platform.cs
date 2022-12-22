using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace videogames_api.Models {
    public class Platform {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPlatform { get; set; }

        public string Name { get; set; } = null!;

        public virtual ICollection<Videogame>? Videogame { get; set; }
    }
}
