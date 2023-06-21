using System;
using System.Collections.Generic;

namespace TestAPI.EntityModels;

public partial class PokemonMovesView
{
    public int? Id { get; set; }

    public string? Name { get; set; }

    public string? Move { get; set; }
}
