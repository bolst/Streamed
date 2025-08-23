using System.Diagnostics.CodeAnalysis;
using MudBlazor;

namespace Streamed.Models.CustomTypes;

public sealed record Category(string Name, string Title, string? Icon, string? IconClass) : CustomTypeBase<string>(Name);

public sealed record Categories
{
    public static Category Hockey { get; } = new("hockey", "Hockey", Icons.Material.Filled.SportsHockey, "deep-purple-text text-lighten-3");
    public static Category Football { get; } = new("american-football", "Football", Icons.Material.Filled.SportsFootball, "brown-text text-lighten-3");
    public static Category Baseball { get; } = new("baseball", "Baseball", Icons.Material.Filled.SportsBaseball, "blue-text text-lighten-3");
    public static Category Basketball { get; } = new("basketball", "Basketball", Icons.Material.Filled.SportsBasketball, "orange-text text-lighten-3");
    public static Category Golf { get; } = new("golf", "Golf", Icons.Material.Filled.SportsGolf, "green-text text-lighten-3");
    public static Category Fight { get; } = new("fight", "Fight", Icons.Material.Filled.SportsMma, "red-text text-lighten-3");
    
    public static IReadOnlyList<Category> All { get; } = [Hockey, Football, Baseball, Basketball, Golf, Fight];

    private static IReadOnlyDictionary<string, Category> _categoryDict = All.ToDictionary(x => x.Value);
    public static bool TryGet(string category, [NotNullWhen(true)] out Category value) => _categoryDict.TryGetValue(category, out value);

}