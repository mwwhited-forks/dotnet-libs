using System;
using System.ComponentModel.DataAnnotations;

namespace Eliassen.MongoDB.Tests;

public class TestCollection
{
    [Key]
    public string? TestId { get; set; }

    public string? Value1 { get; set; }
    public DateTimeOffset Date { get; internal set; }
}
