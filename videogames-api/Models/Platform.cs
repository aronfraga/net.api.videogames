using System;
using System.Collections.Generic;

namespace videogames_api.Models;

public partial class Platform
{
    public int IdPlatforms { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Videogame> Videogames { get; } = new List<Videogame>();
}
