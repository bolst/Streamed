using System.ComponentModel;

namespace Streamed.Enums;

public enum GetMatchType
{
    [Description("all")]
    All,
    
    [Description("all/popular")]
    AllPopular,
    
    [Description("all-today")]
    AllToday,
    
    [Description("all-today/popular")]
    AllTodayPopular,
    
    [Description("live")]
    Live,
    
    [Description("live/popular")]
    LivePopular,
    
    [Description("sport")]
    Sport,
    
    [Description("sport/popular")]
    SportPopular,
}
