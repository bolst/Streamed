namespace Streamed.Models;

public sealed record MatchStream
{
    public string id { get; init; }
    public int streamNo  { get; init; }
    public string language { get; init; }
    public bool hd { get; init; }
    public string embedUrl { get; init; }
    public string source { get; init; }
}