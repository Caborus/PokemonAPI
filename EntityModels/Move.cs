using System;
using System.Collections.Generic;

namespace TestAPI.EntityModels;

public partial class Move
{
    public int Id { get; set; }

    public string Move1 { get; set; } = null!;

    public virtual ICollection<Pokemon> Pokemons { get; set; } = new List<Pokemon>();
}
