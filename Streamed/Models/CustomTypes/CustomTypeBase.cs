namespace Streamed.Models.CustomTypes;

public abstract record CustomTypeBase<T>(T Value)
{
    public static bool operator ==(CustomTypeBase<T> a, T b) => a.Value is null ?
        b is null :
        a.Value.Equals(b);
    
    public static bool operator !=(CustomTypeBase<T> a, T b) => !(a == b);
    
    public static bool operator ==(T a, CustomTypeBase<T> b) => b == a;
    
    public static bool operator !=(T a, CustomTypeBase<T> b) => !(a == b);
    
    
}