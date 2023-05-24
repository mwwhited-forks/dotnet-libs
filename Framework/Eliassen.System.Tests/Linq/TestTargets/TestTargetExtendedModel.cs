using Eliassen.System.ComponentModel;
using System;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Eliassen.System.Tests.Linq.TestTargets
{
    [Searchable(FirstNameLastName)]
    [Searchable(LastNameFirstName)]
    [DebuggerDisplay("{FirstName} {LastName}")]
    public class TestTargetExtendedModel
    {
        public const string FirstNameLastName = nameof(FirstNameLastName);
        public const string LastNameFirstName = nameof(LastNameFirstName);

        public TestTargetExtendedModel(int index)
        {
            Index = index;
            FName = $"{nameof(FName)}{1000 - index:0000}";
            LName = $"{nameof(LName)}{index:0000}";
            Email = $"{nameof(Email)}{index:0000}@domain.com";
        }

        public int Index { get; set; }
        [Searchable]
        public string FName { get; set; }
        [Searchable]
        public string LName { get; set; }
        [Searchable]
        public string Email { get; set; }


        public static Expression<Func<TestTargetExtendedModel, object>>? PropertyMap(string key) =>
            key switch
            {
                "FirstNameLastName" => e => e.FName + " " + e.LName,
                "LastNameFirstName" => e => e.LName + " " + e.FName,
                _ => null
            };
    }
}
