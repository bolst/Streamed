using Streamed.Enums;
using Streamed.Models;

namespace Streamed.Services;

public interface IStreamService
{
    Task<IEnumerable<Match>> GetMatchesAsync(GetMatchType type, string? sport = null);
    Task<IEnumerable<MatchStream>> GetMatchStreamsAsync(string matchId, GetStreamType type = GetStreamType.Alpha);
    Task<IEnumerable<MatchStream>> GetMatchStreamsAsync(string matchId, string type);
}