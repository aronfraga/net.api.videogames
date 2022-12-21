using System;
using System.Collections.Generic;

namespace videogames_api.Models;

public partial class Genre
{
    public int IdGenre { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Videogame> Videogames { get; } = new List<Videogame>();
}
