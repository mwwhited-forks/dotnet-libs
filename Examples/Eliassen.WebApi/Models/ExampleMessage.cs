using System.Text.Json.Nodes;

namespace Eliassen.WebApi.Models;

public class ExampleMessageModel
{
    public string Input { get; set; } = "Default Value";

    public JsonNode? Data { get; set; }
}
