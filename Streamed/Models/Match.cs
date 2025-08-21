using System.Text.Json.Serialization;

namespace Streamed.Models;

public sealed record Match
{
    public string id { get; init; }
    public string title { get; init; }
    public string category { get; init; }
    public long date { get; init; }
    public string? poster { get; init; }
    public bool popular { get; init; }
    public MatchTeams? teams { get; init; }
    public IEnumerable<Source> sources { get; init; }

    public string Image => poster is not null
        ? (Environment.GetEnvironmentVariable("BaseUrl__Streamed") + poster)
        : "https://gomomentus.com/hubfs/Momentus%20Website%20Assets%20-%20NB%202023/Solutions%20-%20Stadiums%20and%20Arenas/5%20Stadium%20and%20Arena%20Card.jpg";
    
    public DateTimeOffset MatchDate => DateTimeOffset.FromUnixTimeMilliseconds(date).AddHours(-4);
}


public sealed record MatchTeams
{
    public MatchTeam? home { get; init; }
    public MatchTeam? away { get; init; }
}


public sealed record MatchTeam
{
    /// <summary>
    /// Team name
    /// </summary>
    public string name { get; init; }
    
    /// <summary>
    /// URL path to team badge
    /// </summary>
    public string badge { get; init; }
}