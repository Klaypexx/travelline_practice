using Accommodations.Dto;

namespace Accommodations.Validation;
public static class ParserData
{
    public static DateTime? DateTimeParse(string value)
    {
        try
        {
            return DateTime.Parse(value);
        }
        catch
        {
            return null;
        }
    }

    public static T? EnumParse<T>(string value) where T : struct
    {
        try
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }
        catch
        {
            return null;
        }
    }

    public static Guid? GuidParse(string value)
    {
        try
        {
            return Guid.Parse(value);
        }
        catch
        {
            return null;
        }
    }

    public static object ThrowIfNull(this object obj, string objText)
    {
        if (obj == null)
        {
            throw new ArgumentException(objText);
        }
        else
        {
            return obj;
        }
    }
}
