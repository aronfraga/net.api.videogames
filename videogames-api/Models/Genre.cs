using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace videogames_api.Models {
    public class Genre {

        public Genre(){
            this.Videogames = new HashSet<Videogame>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdGenre { get; set; }

        public string Name { get; set; } = null!;
        
        [JsonIgnore]
        public virtual ICollection<Videogame> Videogames { get; set; }
    }
}
