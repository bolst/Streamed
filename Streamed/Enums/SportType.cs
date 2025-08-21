using Streamed.Extensions;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace Streamed.Enums;

public enum SportType
{
    [Description("hockey")]
    Hockey,

    [Description("baseball")]
    Baseball,

    [Description("basketball")]
    Basketball,

    [Description("golf")]
    Golf,

    [Description("fight")]
    Fight,

}


public class SportTypes
{
    public static IReadOnlyList<SportType> All { get; } = [SportType.Hockey, SportType.Baseball, SportType.Basketball, SportType.Fight, SportType.Golf];

    private static IReadOnlyDictionary<string, SportType> _sportDict = All.ToDictionary(x => x.ToDescriptionString());

    public static bool TryGet(string sportType, [NotNullWhen(true)] out SportType sport) => _sportDict.TryGetValue(sportType, out sport);
}