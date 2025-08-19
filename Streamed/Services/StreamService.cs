using Streamed.Enums;
using Streamed.Extensions;
using Streamed.Models;

namespace Streamed.Services;

public class StreamService(string baseUrl, ICacheService cacheService) : IStreamService
{

    private readonly HttpClient _http = new()
    {
        BaseAddress = new Uri(baseUrl ?? throw new ArgumentNullException(nameof(baseUrl))),
    };

    private readonly ICacheService _cacheService = cacheService;


    private async Task<T?> HttpGetAsync<T>(string url, bool useCache = true, int cacheDurationMins = 10)
    {
        if (useCache)
        {
            return await _cacheService.GetOrAddAsync(
                url,
                async () => await HttpGetAsync<T>(url, false),
                TimeSpan.FromMinutes(cacheDurationMins)
                );
        }

        try
        {
            return await _http.GetFromJsonAsync<T>(url);
        }
        catch (Exception ex)
        {
            return default;
        }
        
    }


    public async Task<IEnumerable<Match>> GetMatchesAsync(GetMatchType type, string? sport = null)
    {
        if (type is GetMatchType.Sport or GetMatchType.SportPopular && string.IsNullOrEmpty(sport)) throw new ArgumentException("If type is GetMatchType.Sport or GetMatchType.SportPopular, a sport must be given");

        var urlArg = type switch
        {
            GetMatchType.Sport => $"{sport}",
            GetMatchType.SportPopular => $"{sport}/popular",
            _ => type.ToDescriptionString()
        };

        return await HttpGetAsync<Match[]>($"api/matches/{urlArg}") ?? [];
    }



    public async Task<IEnumerable<MatchStream>> GetMatchStreamsAsync(string matchId, GetStreamType type = GetStreamType.Alpha)
        => await GetMatchStreamsAsync(matchId, type.ToDescriptionString());

    public async Task<IEnumerable<MatchStream>> GetMatchStreamsAsync(string matchId, string type)
        => await HttpGetAsync<MatchStream[]>($"api/stream/{type}/{matchId}") ?? [];

}