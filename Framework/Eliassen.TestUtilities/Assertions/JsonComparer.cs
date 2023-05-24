using JsonDiffPatchDotNet;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Eliassen.TestUtilities.Assertions
{
    public static class JsonComparer
    {
        public static void AssertDifferences(this TestContext testContext, object? expected, object? results, string[]? excludePaths = default, bool normalize = true)
        {
            AssertDifferences(testContext, tryConvert(expected), tryConvert(results), excludePaths, normalize);

            static JToken? tryConvert(object? input)
            {
                try
                {
                    return input == null ? null : JsonConvert.SerializeObject(input);
                }
                catch (Exception ex)
                {
                    Trace.WriteLine(ex.Message, "Exception-Message");
                    Trace.WriteLine(ex, "Exception");
                    return default;
                }
            }
        }

        public static void AssertDifferences(this TestContext testContext, string? expected, string? results, string[]? excludePaths = default, bool normalize = true)
        {
            AssertDifferences(testContext, tryParse(expected), tryParse(results), excludePaths, normalize);

            static JToken? tryParse(string? input)
            {
                try
                {
                    return string.IsNullOrWhiteSpace(input) ? null : JToken.Parse(input);
                }
                catch (Exception ex)
                {
                    Trace.WriteLine(ex.Message, "Exception-Message");
                    Trace.WriteLine(ex, "Exception");
                    return null;
                }
            }
        }

        public static void AssertDifferences(this TestContext testContext, JToken? expected, JToken? results, string[]? excludePaths = default, bool normalize = true)
        {
            if (expected == null)
            {
                Assert.Inconclusive($"No expected results defined.");
                return;
            }

            if (results == null)
            {
                Assert.Inconclusive($"No results provided.");
                return;
            }

            //Note: this will defuzz the data types versus how deepclone works.
            var eClone = JToken.Parse(expected.ToString());
            var rClone = JToken.Parse(results.ToString());

            foreach (var excludePath in excludePaths ?? Enumerable.Empty<string>())
            {
                var eRemove = eClone.SelectTokens(excludePath).ToArray();
                var rRemove = rClone.SelectTokens(excludePath).ToArray();

                foreach (var remove in eRemove.Concat(rRemove))
                    remove.Parent?.Remove();
            }

            if (normalize)
            {
                eClone = Normalize(eClone);
                rClone = Normalize(rClone);
                testContext.AddResult(rClone, fileName: "Normalized-Results.json");
            }

            var jdp = new JsonDiffPatch();
            var differences = jdp.Diff(eClone.ToString(), rClone.ToString());

            if (differences == null) return; // inputs match

            testContext.AddResult(differences, fileName: "ComparedResults.json");

            Assert.Fail("Results do not match Expected.  Review ComparedResults for more details.");
        }

        public static JToken Normalize(JToken input) => input switch
        {
            JObject job => new JObject(job.Properties().OrderBy(i => i.Name).Select(s => Normalize(s))),
            JProperty jpo => new JProperty(jpo.Name, Normalize(jpo.Value)),
            JArray jar => new JArray(jar.Children().Select(i => Normalize(i)).OrderBy(i => i, new JTokenComparer())),

            JValue jval =>
                long.TryParse(jval.Value?.ToString(), out var lng) ? new JValue(lng) :
                decimal.TryParse(jval.Value?.ToString(), out var dev) ? new JValue(dev) :
                double.TryParse(jval.Value?.ToString(), out var dolb) ? new JValue(dolb) :
                DateTimeOffset.TryParse(jval.Value?.ToString(), out var dt) ? new JValue(dt.UtcDateTime) :
                Guid.TryParse(jval.Value?.ToString(), out var guid) ? new JValue(guid) :
                bool.TryParse(jval.Value?.ToString(), out var bol) ? new JValue(bol) :
                jval,

            _ => input
        };
        public class JTokenComparer : IComparer<JToken>
        {
            public int Compare(JToken x, JToken y)
            {
                var compared = x.Type.CompareTo(y.Type);
                if (compared != 0) return compared;
                else if (x is JValue jv && y is JValue yv) return jv.CompareTo(yv);
                else if (x is JArray xa && y is JArray ya) return xa.Count - ya.Count switch
                {
                    int ret when ret == 0 => ret,
                    int ret => ret
                };
                else if (x is JObject xo && y is JObject yo)
                {
                    var xop = xo.Properties().OrderBy(p => p.Name).ToArray();
                    var yop = yo.Properties().OrderBy(p => p.Name).ToArray();

                    var aligned = xop.Zip(yop, (xz, yz) => xz.Name.CompareTo(yz.Name) switch
                    {
                        0 => Compare(xz.Value, yz.Value),
                        int ret => ret
                    });
                    var xyr = aligned.Sum();
                    return xyr;
                }
                return -999;
            }
        }

        public static void AssertDifferences(this TestContext testContext, object results, string[]? excludePaths = default, bool normalize = true) =>
            AssertDifferences(testContext, testContext.TestName, results, excludePaths, normalize);

        public static void AssertDifferences(this TestContext testContext, string testName, object results, string[]? excludePaths = default, bool normalize = true)
        {
            var jsonResults = results == null ? null : JToken.FromObject(results);
            var expected = testContext.GetTestDataAsync<JToken>($"{testName}.Expected").GetAwaiter().GetResult();
            testContext.AddResult(results, fileName: "Results.json");

            if (expected == null)
            {
                Assert.Inconclusive($"No expected results defined.  Add a resource named {testName}.Expected.json based on the results from Results.json attached to this test.");
            }

            var excludeValues = testContext.GetTestDataAsync<string[]>($"{testName}.Exclude").GetAwaiter().GetResult() ?? Array.Empty<string>();

            AssertDifferences(testContext, expected, jsonResults, (excludePaths ?? Array.Empty<string>()).Concat(excludeValues).ToArray(), normalize);
        }

    }
}
