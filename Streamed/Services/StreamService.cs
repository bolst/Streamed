using Streamed.Enums;
using Streamed.Extensions;
using Streamed.Models;

namespace Streamed.Services;

public class StreamService(string baseUrl) : IStreamService
{

    private readonly HttpClient _http = new()
    {
        BaseAddress = new Uri(baseUrl ?? throw new ArgumentNullException(nameof(baseUrl))),
    };



    public async Task<IEnumerable<Match>> GetMatchesAsync(GetMatchType type, string? sport = null)
    {
        if (type is GetMatchType.Sport or GetMatchType.SportPopular && string.IsNullOrEmpty(sport)) throw new ArgumentException("If type is GetMatchType.Sport or GetMatchType.SportPopular, a sport must be given");

        var urlArg = type switch
        {
            GetMatchType.Sport => $"{sport}",
            GetMatchType.SportPopular => $"{sport}/popular",
            _ => type.ToDescriptionString()
        };
        
        return await _http.GetFromJsonAsync<Match[]>($"api/matches/{urlArg}") ?? [];
    }



    public async Task<IEnumerable<MatchStream>> GetMatchStreamsAsync(string matchId, GetStreamType type = GetStreamType.Alpha)
        => await GetMatchStreamsAsync(matchId, type.ToDescriptionString());

    public async Task<IEnumerable<MatchStream>> GetMatchStreamsAsync(string matchId, string type)
        => await _http.GetFromJsonAsync<MatchStream[]>($"api/stream/{type}/{matchId}") ?? [];

}