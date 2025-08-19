namespace Streamed.Extensions;

public static class StringExtensions
{
    public static string Caption(this string str, int length = 50) =>
        str.Length <= length ? str : str[..length] + "...";
    
    public static bool EqualsEnum(this string str, Enum other) => str.Equals(other.ToDescriptionString());
}