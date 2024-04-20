using Eliassen.TestUtilities;
using OllamaSharp;
using System.Diagnostics;

namespace Eliassen.Ollama.Tests;


[TestClass]
public class OllamaApiClientTests
{
    public required TestContext TestContext { get; set; }

    [TestCategory(TestCategories.DevLocal)]
    [DataTestMethod]
    [DataRow("192.168.1.170", "llama2:13b")]
    public async Task GenerateEmbeddingsDoubleTest(string hostName, string model)
    {
        var client = new OllamaApiClientFactory().Build(hostName);
        var embedding = await client.GenerateEmbeddings(new()
        {
            Model = model,
            Prompt = "Hello World!",
        });

        this.TestContext.WriteLine(string.Join(", ", embedding.Embedding));
    }

    [TestCategory(TestCategories.DevLocal)]
    [DataTestMethod]
    [DataRow("192.168.1.170", "llama2:13b")]
    public async Task GenerateEmbeddingsSingleTest(string hostName, string model)
    {
        var client = new OllamaApiClientFactory().Build(hostName);
        var embedding = await client.GenerateEmbeddings(new()
        {
            Model = model,
            Prompt = "Hello World!",
        });

        this.TestContext.WriteLine(string.Join(", ", Array.ConvertAll(embedding.Embedding, Convert.ToSingle)));
    }

    [TestCategory(TestCategories.DevLocal)]
    [DataTestMethod]
    [DataRow("192.168.1.170", "llama2:13b")]
    public async Task GenerateEmbeddingsSingleExpandedTest(string hostName, string model)
    {
        var client = new OllamaApiClientFactory().Build(hostName);
        var embedding = await client.GenerateEmbeddings(new()
        {
            Model = model,
            Prompt = "Hello World!",
        });

        this.TestContext.WriteLine(
            string.Join(", ",
            Array.ConvertAll(embedding.Embedding, d => new[] {
                    (float)d,
                    (float)(d * 10000000 - (float)d * 10000000)
                }).SelectMany(i => i)
            ));
    }


    [TestCategory(TestCategories.DevLocal)]
    [DataTestMethod]
    [DataRow("192.168.1.170", "llama2:13b")]
    public async Task GetCompletionTest(string hostName, string model)
    {
        var client = new OllamaApiClientFactory().Build(hostName);
        var embedding = await client.GetCompletion(new()
        {
            Model = model,
            Prompt = "Create a hello world script for windows command prompt",
        });

        this.TestContext.WriteLine(embedding.Response);
    }


    [TestCategory(TestCategories.DevLocal)]
    [DataTestMethod]
    [DataRow("192.168.1.170")]
    public async Task ListModelsTest(string hostName)
    {
        var client = new OllamaApiClientFactory().Build(hostName);
        foreach (var localModel in await client.ListLocalModels())
            this.TestContext.WriteLine($"model: {localModel.Name}");
    }


    [TestCategory(TestCategories.DevLocal)]
    [DataTestMethod]
    //[DataRow("192.168.1.170", "codellama")]
    //[DataRow("192.168.1.170", "neural-chat")]
    [DataRow("192.168.1.170", "llama2:7b")]
    //[DataRow("192.168.1.170", "llama2:13b")]
    [DataRow("192.168.1.170", "phi")]
    //[DataRow("192.168.1.170", "orca-mini:7b")]
    //[DataRow("192.168.1.170", "orca-mini:3b")]
    //[DataRow("192.168.1.170", "gemma:2b")]
    //[DataRow("192.168.1.170", "gemma:7b")]
    //[DataRow("192.168.1.170", "mistral")]
    [DataRow("192.168.1.170", "mistral:instruct")]
    //[DataRow("192.168.1.170", "mistral:text")]
    //[DataRow("192.168.1.170", "mixtral")]
    //[DataRow("192.168.1.170", "mixtral:instruct")]
    //[DataRow("192.168.1.170", "mixtral:text")]
    public async Task PullModelTest(string hostName, string modelName)
    {
        var client = new OllamaApiClientFactory().Build(hostName);
        double? last = default;
        await client.PullModel(modelName, ps =>
        {
            if (ps.Percent != last)
            {
                Debug.WriteLine($"{modelName}: Pulled: {ps.Percent}%");
                last = ps.Percent;
            }
        });
    }

    //[DataTestMethod]
    //[DataRow("192.168.1.170", "joe")]
    //[DataRow("192.168.1.170", "r2d2")]
    //[DataRow("192.168.1.170", "codellama")]
    //[DataRow("192.168.1.170", "neural-chat")]
    ////[DataRow("192.168.1.170", "llama2:7b")]
    ////[DataRow("192.168.1.170", "llama2:13b")]
    ////[DataRow("192.168.1.170", "phi")]
    //[DataRow("192.168.1.170", "orca-mini:7b")]
    //[DataRow("192.168.1.170", "orca-mini:3b")]
    //[DataRow("192.168.1.170", "gemma:2b")]
    //[DataRow("192.168.1.170", "gemma:7b")]
    ////[DataRow("192.168.1.170", "mistral")]
    ////[DataRow("192.168.1.170", "mistral:instruct")]
    ////[DataRow("192.168.1.170", "mistral:text")]
    //[DataRow("192.168.1.170", "mixtral")]
    ////[DataRow("192.168.1.170", "mixtral:instruct")]
    //[DataRow("192.168.1.170", "mixtral:text")]
    //public async Task DeleteModelTest(string hostname, string modelName)
    //{
    //    var client = new OllamaApiClientFactory().Build(hostname);
    //    await client.DeleteModel(modelName);
    //}


    //    [DataTestMethod]
    //    //[DataRow("192.168.1.170", "what is the weather", "llama2:latest")]
    //    //[DataRow("192.168.1.170", "where are you located", "llama2:latest")]
    //    //[DataRow("192.168.1.170", "what time is it", "llama2:latest")]
    //    //[DataRow("192.168.1.170", "who are you", "llama2:latest")]

    //    //[DataRow("192.168.1.170", "what is the weather where you are", "llama2:13b")]
    //    //[DataRow("192.168.1.170", "what is the weather where I am", "llama2:13b")]
    //    //[DataRow("192.168.1.170", "what is the weather in columbus ohio", "llama2:13b")]
    //    //[DataRow("192.168.1.170", "what is the weather in ohio", "llama2:13b")]
    //    //[DataRow("192.168.1.170", "what is the weather in NY", "llama2:13b")]
    //    //[DataRow("192.168.1.170", "where are you located", "llama2:13b")]
    //    //[DataRow("192.168.1.170", "what time is it", "llama2:13b")]
    //    //[DataRow("192.168.1.170", "who are you", "llama2:13b")]

    //    [DataRow("192.168.1.170", "who are you", "joe", "service-registry")]
    //    [DataRow("192.168.1.170", "who are you", "llama2", "service-registry")]
    //    [DataRow("192.168.1.170", "who are you", "llama2:13b", "service-registry")]
    //    [DataRow("192.168.1.170", "who are you", "r2d2", "service-registry")]
    //    public async Task RagTest(string hostname, string question, string model, string serviceCollectionName)
    //    {
    //        var ollama = new OllamaApiClientFactory().Build(hostname);
    //        var qdrant = new QdrantGrpcClientFactory().Build($"http://{hostname}:6334");
    //        var rag = new RagRunner(
    //            ollama,
    //            model,
    //            new PromptBuilder(),
    //            new ServiceRegistry(ollama, qdrant, new PointStructFactory(), model, serviceCollectionName)
    //            );

    //        var result = await rag.RunAsync(question);

    //        Assert.IsNotNull(result);

    //        this.TestContext.WriteLine("----==== Response ====----");
    //        this.TestContext.WriteLine(result?.ToString()); // .SplitBy(length: 40).WriteAsLines()
    //    }

    //    [DataTestMethod]
    //    //[DataRow("192.168.1.170", "what is the weather where I am", "llama2:")]
    //    //[DataRow("192.168.1.170", "what is the weather in columbus ohio", "llama2:13b")]
    //    //[DataRow("192.168.1.170", "what is the weather in ohio", "llama2:13b")]
    //    //[DataRow("192.168.1.170", "what is the weather in NY", "llama2:13b")]

    //    //[DataRow("192.168.1.170", "where are you located", "llama2:13b")]
    //    //[DataRow("192.168.1.170", "what time is it", "llama2:13b")]
    //    //[DataRow("192.168.1.170", "who are you", "llama2:13b")]

    //    [DataRow("192.168.1.170", "what is the weather in Columbus Ohio", "llama2")]
    //    [DataRow("192.168.1.170", "what is the weather in Columbus Ohio", "llama2:13b")]
    //    [DataRow("192.168.1.170", "what is the weather in Columbus Ohio", "phi")]

    //    //[DataRow("192.168.1.170", "what is the weather where you are", "joe")]
    //    //[DataRow("192.168.1.170", "what is the weather where you are", "llama2")]
    //    //[DataRow("192.168.1.170", "what is the weather where you are", "llama2:13b")]
    //    //[DataRow("192.168.1.170", "what is the weather where you are", "r2d2")]
    //    //[DataRow("192.168.1.170", "what is the weather where you are", "phi")]

    //    [DataRow("192.168.1.170", "what is your name?", "llama2")]
    //    [DataRow("192.168.1.170", "what is your name?", "llama2:13b")]
    //    [DataRow("192.168.1.170", "what is your name?", "phi")]

    //    public async Task GetCompletion(string hostname, string question, string model)
    //    {
    //        IServiceInstance[] instance = [
    //            new LocalTimeProvider(),
    //            new WeatherLookupProvider(),
    //        ];

    //        var ollama = new OllamaApiClientFactory().Build(hostname);
    //        ollama.SelectedModel = model;



    //        var prompt = $@"
    //Using this information only answer the user's question.
    //Additional Information: 
    //The sky is green. The clouds are purple. The time is 1:21am. The date is December 3rd 1972.  Your name is Tim.
    //The current temperature is 75.4F.

    //User's question: {question}";  //question;
    //        //$"Answer YES or NO\r\n" +
    //        //$"Is the following asking about the weather\r\n" +
    //        //$"{question}";

    //        this.TestContext.WriteLine($"Prompt: {prompt}");

    //        var results = await ollama.GetCompletion(new()
    //        {
    //            Model = model,
    //            Prompt = prompt,


    //            //Context = _context,
    //            //Raw = true,
    //            //System = prompt,
    //        }); ;

    //        this.TestContext.WriteLine($"Response: {string.Join(Environment.NewLine, results.Response.SplitBy(40))}");
    //        //  _context = results.Context;

    //        //this.TestContext.WriteLine($"Context: {string.Join(", ", )}");
    //    }
    //    //private static long[] _context;

    //    [DataTestMethod]
    //    [DataRow("joe")]
    //    [DataRow("r2d2")]
    //    public async Task CreateModelTest(string modelName)
    //    {
    //        var ollama = new OllamaApiClientFactory().Build("192.168.1.170");

    //        if ((await ollama.ListLocalModels()).Any(l => l.Name.StartsWith($"{modelName}:")))
    //        {
    //            this.TestContext.WriteLine($"Deleting model: {modelName}");
    //            await ollama.DeleteModel(modelName);
    //        }

    //        var resource = $"{this.GetType().Namespace}.models.{modelName}-model.txt";
    //        using var stream = this.GetType().Assembly.GetManifestResourceStream(resource);
    //        using var reader = new StreamReader(stream);
    //        var modelContent = reader.ReadToEnd();

    //        this.TestContext.WriteLine($"=== Model Definition: {modelName}");
    //        this.TestContext.WriteLine(modelContent);

    //        if (!string.IsNullOrWhiteSpace(modelContent))
    //        {
    //            this.TestContext.WriteLine($"=== Create Model: {modelName}");
    //            await ollama.CreateModel(
    //                modelName, modelContent,
    //                status => this.TestContext.WriteLine(status.Status));
    //        }

    //        this.TestContext.WriteLine($"done!");
    //    }

    //    [DataTestMethod]
    //    [DataRow("192.168.1.170", "phi", "what is the weather", "what is the weather in new york")]
    //    [DataRow("192.168.1.170", "phi", "what is the weather", "what is the time")]
    //    [DataRow("192.168.1.170", "phi", "what is the weather", "what is the date")]

    //    [DataRow("192.168.1.170", "llama2:7b", "what is the weather", "what is the weather in new york")]
    //    [DataRow("192.168.1.170", "llama2:7b", "what is the weather", "what is the time")]
    //    [DataRow("192.168.1.170", "llama2:7b", "what is the weather", "what is the date")]

    //    [DataRow("192.168.1.170", "llama2:13b", "what is the weather", "what is the weather in new york")]
    //    [DataRow("192.168.1.170", "llama2:13b", "what is the weather", "what is the time")]
    //    [DataRow("192.168.1.170", "llama2:13b", "what is the weather", "what is the date")]

    //    [DataRow("192.168.1.170", "llama2:latest", "what is the weather", "what is the weather in new york")]
    //    [DataRow("192.168.1.170", "llama2:latest", "what is the weather", "what is the time")]
    //    [DataRow("192.168.1.170", "llama2:latest", "what is the weather", "what is the date")]

    //    public async Task CompareEmbeddings(string host, string model, string query1, string query2)
    //    {
    //        var ollama = new OllamaApiClientFactory().Build(host);
    //        //ollama.SelectedModel = model;

    //        var embedding1 = (await ollama.GenerateEmbeddings(new()
    //        {
    //            Model = model,
    //            Prompt = query1,
    //        })).Embedding;

    //        var embedding2 = (await ollama.GenerateEmbeddings(new()
    //        {
    //            Model = model,
    //            Prompt = query2,
    //        })).Embedding;

    //        Console.WriteLine($"model: {model}");
    //        Console.WriteLine($"query 1: {query1}");
    //        Console.WriteLine($"query 2: {query2}");
    //        Console.WriteLine($"embedding length: {embedding1.Length}");

    //        var cosineSimilarity = embedding1.Zip(embedding2).Sum(i => i.First * i.Second) / (
    //                Math.Sqrt(embedding1.Sum(a => a * a)) * Math.Sqrt(embedding2.Sum(b => b * b))
    //                );
    //        Console.WriteLine($"cosine similarity: {cosineSimilarity}");

    //        var euclideanDistance = Math.Sqrt(embedding1.Zip(embedding2).Sum(i => Math.Pow(i.First - i.Second, 2)));
    //        Console.WriteLine($"euclidean distance: {euclideanDistance}");

    //        var manhattanDistance = embedding1.Zip(embedding2).Sum(i => Math.Abs(i.First - i.Second));
    //        Console.WriteLine($"manhattan distance: {manhattanDistance}");

    //    }

    //    [DataTestMethod]
    //    //[DataRow("192.168.1.170", "phi", "SearchQueryMiddleware.md")]
    //    [DataRow("192.168.1.170", "llama2:13b", "SearchQueryMiddleware.md")]
    //    //[DataRow("192.168.1.170", "llama2:7b", "SearchQueryMiddleware.md")]

    //    //[DataRow("192.168.1.170", "phi", "Eliassen.System.md")]
    //    //// [DataRow("192.168.1.170", "llama2:13b", "Eliassen.System.md")]
    //    //[DataRow("192.168.1.170", "llama2:7b", "Eliassen.System.md")]

    //    public async Task SummerizeDocumentTest(string hostName, string modelName, string fileName)
    //    {
    //        var ollama = new OllamaApiClientFactory().Build(hostName);
    //        ollama.SelectedModel = modelName;

    //        //var promptTemplate = @"Write a concise summary of the following text delimited by triple backquotes.
    //        //      Return your response in bullet points which covers the key points of the text.
    //        //      ```{0}```
    //        //      BULLET POINT SUMMARY:";

    //        //var promptTemplate = @"Write a concise summary of the following text delimited by triple backquotes.
    //        //      Return your response in single paragraph which covers the key points of the text.
    //        //      ```{0}```
    //        //      SUMMARY:";


    //        var promptTemplate = @"summarize this content

    //{0}";


    //        var resource = $"{this.GetType().Namespace}.models.{fileName}";
    //        using var stream = this.GetType().Assembly.GetManifestResourceStream(resource);
    //        using var reader = new StreamReader(stream);
    //        var content = reader.ReadToEnd();

    //        var result = await DoCompletionAsync(ollama, modelName, promptTemplate, content.Replace("```", "---"));
    //        this.TestContext.WriteLine(result);

    //    }

    //    [DataTestMethod]
    //    [DataRow("192.168.1.170", "phi", "SearchQueryMiddleware.md")]
    //    [DataRow("192.168.1.170", "llama2:7b", "SearchQueryMiddleware.md")]
    //    [DataRow("192.168.1.170", "llama2:13b", "SearchQueryMiddleware.md")]
    //    [DataRow("192.168.1.170", "mistral:instruct", "SearchQueryMiddleware.md")]
    //    //[DataRow("192.168.1.170", "mistral:text", "SearchQueryMiddleware.md")]
    //    //[DataRow("192.168.1.170", "mixtral:instruct", "SearchQueryMiddleware.md")]

    //    //[DataRow("192.168.1.170", "phi", "Eliassen.System.md")]
    //    //[DataRow("192.168.1.170", "llama2:7b", "Eliassen.System.md")]
    //    public async Task SubSummerizeDocumentTest(string hostName, string modelName, string fileName)
    //    {
    //        var ollama = new OllamaApiClientFactory().Build(hostName);
    //        ollama.SelectedModel = modelName;

    //        //var promptTemplate = @"Write a concise summary of the following text delimited by triple backquotes.
    //        //      Return your response in bullet points which covers the key points of the text.
    //        //      ```{0}```
    //        //      BULLET POINT SUMMARY:";

    //        var promptTemplate = @"Write a single paragraph of less than 5 sentences to summarize the following text 
    //{0}";

    //        var resource = $"{this.GetType().Namespace}.models.{fileName}";
    //        using var stream = this.GetType().Assembly.GetManifestResourceStream(resource);
    //        using var reader = new StreamReader(stream);

    //        var pass = 0;

    //        var sb = new StringBuilder();
    //        while (!reader.EndOfStream)
    //            sb.Append(await reader.ReadLineAsync()).Append(" ");


    //        var content = sb.ToString();
    //        sb.Clear();
    //        var chunks = content.SplitBy(4096);

    //        foreach (var chunk in chunks.Take(3))
    //        {
    //            var result = await DoCompletionAsync(ollama, modelName, promptTemplate, chunk);
    //            sb.Append(result).Append(" ");
    //            //    Console.WriteLine($"{pass}: {chunk} -> {result.ReplaceLineEndings(" ")}");
    //            //this.TestContext.WriteLine($"{pass}: {chunk} -> {result.ReplaceLineEndings(" ")}");
    //        }

    //        //this.TestContext.WriteLine($"--------------------------------");
    //        //this.TestContext.WriteLine($"{sb.Length} -> {sb}");
    //        //this.TestContext.WriteLine($"================================");


    //        var final = await DoCompletionAsync(ollama, modelName, promptTemplate, sb.ToString());

    //        this.TestContext.WriteLine($"--------------------------------");
    //        this.TestContext.WriteLine($"{final.Length} -> {string.Join(Environment.NewLine, final.SplitBy())}");
    //        this.TestContext.WriteLine($"================================");

    //    }

    //    // https://www.promptingguide.ai/models/mixtral

    //    private async Task<string> DoCompletionAsync(OllamaApiClient ollama, string modelName, string promptTemplate, string content)
    //    {
    //        var prompt = string.Format(promptTemplate, content);

    //        var completion = await ollama.GetCompletion(new OllamaSharp.Models.GenerateCompletionRequest
    //        {
    //            Model = modelName,
    //            Prompt = prompt,
    //        });

    //        return completion.Response;
    //    }
}
