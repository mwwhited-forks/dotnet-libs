using Eliassen.System.ComponentModel.Search;

namespace Eliassen.System.Tests.Linq.TestTargets
{
    public class TestTarget3Model
    {
        [NotSearchable]
        public int Index { get; set; }
        [NotSortable]
        public string Name { get; set; }
        [NotFilterable]
        public string Email { get; set; }
    }
}
