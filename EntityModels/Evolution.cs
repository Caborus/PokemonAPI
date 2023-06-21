using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TestAPI.EntityModels;

public partial class Evolution
{
    public int PokemonId { get; set; }

    public int EvolvesTo { get; set; }

    public string? Trigger { get; set; }

    public virtual Pokemon EvolvesToNavigation { get; set; } = null!;
    
    public virtual Pokemon Pokemon { get; set; } = null!;
}
