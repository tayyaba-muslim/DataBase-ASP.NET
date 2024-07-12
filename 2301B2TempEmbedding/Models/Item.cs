﻿using System;
using System.Collections.Generic;

namespace _2301B2TempEmbedding.Models;

public partial class Item
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public int Price { get; set; }

    public string Image { get; set; } = null!;

    public int? CatId { get; set; }

    public virtual Category? Cat { get; set; }
}
