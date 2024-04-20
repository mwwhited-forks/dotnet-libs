namespace Eliassen.SBert.Tests;

[TestClass]
public class SBertClientTests
{
    public required TestContext TestContext { get; set; }

    //[TestMethod]
    //public async Task Test()
    //{
    //    var client = new SBertClient("http://127.0.0.1:5080");
    //    var embedding = await client.GetEmbeddingAsync("hello world!");

    //    this.TestContext.WriteLine(string.Join(';', embedding));
    //}

    //[DataTestMethod, TestCategory("setup")]
    //[DataRow("192.168.1.170", "example-sbert")]
    //public async Task GetAllTest(string hostName, string collectionName)
    //{
    //    var client = new SBertClient($"http://127.0.0.1:5080");

    //    var resource = this.GetType().Assembly.GetManifestResourceNames().FirstOrDefault(l => l.EndsWith(".sentences.txt"))
    //        ?? throw new ApplicationException("missing .sentences.txt resource");
    //    using var stream = this.GetType().Assembly.GetManifestResourceStream(resource)
    //        ?? throw new ApplicationException("missing .sentences.txt resource");
    //    using var reader = new StreamReader(stream);

    //    var dict = new Dictionary<string, double[]>();

    //    while (!reader.EndOfStream)
    //    {
    //        var line = await reader.ReadLineAsync();
    //        try
    //        {
    //            if (string.IsNullOrWhiteSpace(line.Trim())) continue;

    //            var parts = line.Split([','], 2);
    //            var section = parts[0].Trim();
    //            var segment = parts[1].Trim();

    //            this.TestContext.WriteLine(line);

    //            //var embedding = await client.GetEmbeddingAsync(segment);
    //            var embedding = await client.GetEmbeddingDoubleAsync(segment);

    //            dict.TryAdd(segment, embedding);
    //        }
    //        catch (Exception ex)
    //        {
    //            this.TestContext.WriteLine($"ERROR: \"{line}\" -> {ex.Message}");
    //        }
    //    }

    //    var each = from a in dict
    //               from b in dict
    //               let dotproduct = a.Value.Zip(b.Value).Select(i => i.First * i.Second).Sum()
    //               let vma = Math.Sqrt(a.Value.Select(i => i * i).Sum())
    //               let vmb = Math.Sqrt(b.Value.Select(i => i * i).Sum())
    //               select new
    //               {
    //                   A = a.Key,
    //                   B = b.Key,
    //                   Dotproduct = dotproduct,
    //                   ConsineSimilarity = dotproduct / (vma * vmb),
    //                   EuclideanDistance = Math.Sqrt(a.Value.Zip(b.Value).Select(i => Math.Pow(i.First - i.Second, 2)).Sum()),
    //                   ManhattanDistance = a.Value.Zip(b.Value).Select(i => Math.Abs(i.First - i.Second)).Sum(),
    //                   VectorMagnitudeA = vma,
    //                   VectorMagnitudeB = vmb,
    //               };

    //    var targetFile = @"C:\Repos\Reference\coe-dotnet\src\OllamanetTest.cli\OllamanetTests\models\results2.txt";
    //    File.WriteAllLines(targetFile, each.Select(i => string.Join('\t',
    //        i.A,
    //        i.B,
    //        i.Dotproduct,
    //        i.ConsineSimilarity,
    //        i.EuclideanDistance,
    //        i.ManhattanDistance,
    //        i.VectorMagnitudeA,
    //        i.VectorMagnitudeB
    //        )).ToArray());

    //    var embeddingFile = @"C:\Repos\Reference\coe-dotnet\src\OllamanetTest.cli\OllamanetTests\models\embeddings2.txt";
    //    File.WriteAllLines(embeddingFile, dict.Select(i => string.Join('\t', i.Key, Convert.ToBase64String(i.Value.Select(i => BitConverter.GetBytes(i)).SelectMany(i => i).ToArray()))));

    //    var embeddingDFile = @"C:\Repos\Reference\coe-dotnet\src\OllamanetTest.cli\OllamanetTests\models\embeddingsd.txt";
    //    File.WriteAllLines(embeddingDFile, dict.Select(i => string.Join('\t', new object[] { i.Key }.Concat(i.Value.Select(i => (object)i)))));

    //    /*
    //                -- https://wikipedia.org/wiki/Euclidean_distance
    //                -- https://www.omnicalculator.com/math/euclidean-distance
    //                ,SQRT(SUM(POWER([$B_Element].[Value] - [$A_Element].[Value],2)))	AS [EuclideanDistance]

    //                -- https://en.wikipedia.org/wiki/Taxicab_geometry
    //                -- https://www.omnicalculator.com/math/manhattan-distance
    //                ,SUM(ABS([$B_Element].[Value] - [$A_Element].[Value]))				AS [ManhattanDistance]
    //    */

    //}
}
