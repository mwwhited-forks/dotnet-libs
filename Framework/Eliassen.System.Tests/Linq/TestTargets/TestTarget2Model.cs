using Eliassen.System.ComponentModel.Search;

namespace Eliassen.System.Tests.Linq.TestTargets
{
    [Searchable("Fake")]
    public class TestTarget2Model
    {
        [NotSortable]
        public int Index { get; set; }
        [Searchable]
        public string Name { get; set; }
        [NotFilterable]
        public string Email { get; set; }
    }
}
