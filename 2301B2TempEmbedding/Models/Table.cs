using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace _2301B2TempEmbedding.Models;

public partial class Table
{
    [Key]
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public int Price { get; set; }
}
