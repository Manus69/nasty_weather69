using System.Text.Json.Nodes;

interface IJSONParser
{
    List<float>? GetTemps(JsonNode jObj);
}