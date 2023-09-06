using System;

public class EnumValidator
{
    public static bool IsEnumValueValid<TEnum>(string value) where TEnum : struct, Enum
    {
        return Enum.TryParse(value, out TEnum result);
    }
}
