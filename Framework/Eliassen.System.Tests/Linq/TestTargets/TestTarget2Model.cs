using Eliassen.System.ComponentModel.Search;
using System.ComponentModel.DataAnnotations;

namespace Eliassen.System.Tests.Linq.TestTargets;

[Searchable("Fake")]
public class TestTarget2Model
{
    [Key]
    [NotSortable]
    public int Index { get; set; }
    [Searchable]
    public string Name { get; set; } = default!;
    [NotFilterable]
    public string Email { get; set; } = default!;
}
