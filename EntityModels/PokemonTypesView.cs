﻿using System;
using System.Collections.Generic;

namespace TestAPI.EntityModels;

public partial class PokemonTypesView
{
    public int? Id { get; set; }

    public string? Name { get; set; }

    public string? Type { get; set; }
}
