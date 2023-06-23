using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;

namespace Eliassen.TestUtilities.Assertions
{
    /// <inheritdoc/>
    public class JTokenComparer : IComparer<JToken>
    {
        /// <inheritdoc/>
        public int Compare(JToken? x, JToken? y)
        {
            if (x == null && y == null) return 0;
            else if (x == null) return int.MaxValue;
            else if (y == null) return int.MinValue;

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
}
