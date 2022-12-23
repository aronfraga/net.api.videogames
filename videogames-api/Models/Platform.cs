using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace videogames_api.Models {
    public class Platform {

        public Platform(){
            this.Videogames = new HashSet<Videogame>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPlatform { get; set; }

        public string Name { get; set; } = null!;

        [JsonIgnore]
        public virtual ICollection<Videogame> Videogames { get; set; }
    }
}
