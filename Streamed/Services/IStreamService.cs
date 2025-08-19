using Streamed.Enums;
using Streamed.Models;

namespace Streamed.Services;

public interface IStreamService
{
    Task<IEnumerable<Match>> GetMatchesAsync(GetMatchType type, string? sport = null);
    Task<MatchStream?> GetMatchStreamAsync(string matchId, GetStreamType type = GetStreamType.Alpha);
}