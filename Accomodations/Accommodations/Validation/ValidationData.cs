using Accommodations.Dto;

namespace Accommodations.Validation;
public static class ValidationData
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

    public static CurrencyDto? CurrentDtoParse(string value)
    {
        try
        {
            return (CurrencyDto)Enum.Parse(typeof(CurrencyDto), value, true);
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
