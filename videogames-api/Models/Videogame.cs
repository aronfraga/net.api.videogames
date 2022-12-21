using System;
using System.Collections.Generic;

namespace videogames_api.Models;

public partial class Videogame
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? ReleaseDate { get; set; }

    public string? Image { get; set; }

    public int? Rating { get; set; }

    public int? Platforms { get; set; }

    public int? Genre { get; set; }

    public virtual Genre? GenreNavigation { get; set; }

    public virtual Platform? PlatformsNavigation { get; set; }
}
