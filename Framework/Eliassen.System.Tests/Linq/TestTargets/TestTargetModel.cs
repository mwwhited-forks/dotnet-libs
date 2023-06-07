using System.ComponentModel.DataAnnotations;

namespace Eliassen.System.Tests.Linq.TestTargets
{
    public class TestTargetModel
    {
        public TestTargetModel(int index)
        {
            Index = index;
            Name = $"{nameof(Name)}{index}";
            Email = $"{nameof(Email)}{index:000}@domain.com";
        }

        [Key]
        public int Index { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
