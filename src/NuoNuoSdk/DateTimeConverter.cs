using System.Globalization;

namespace NuoNuoSdk;

/// <summary>
/// 日期时间转换器，支持yyyy-MM-dd HH:mm:ss格式
/// </summary>
public class DateTimeConverter : JsonConverter<DateTime>
{
    private const string DateTimeFormat = "yyyy-MM-dd HH:mm:ss";

    public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        string dateString = reader.GetString();
        if (string.IsNullOrEmpty(dateString))
            return default;

        if (DateTime.TryParseExact(dateString, DateTimeFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime result))
            return result;

        // 如果解析失败，尝试使用默认解析
        if (DateTime.TryParse(dateString, out result))
            return result;

        throw new JsonException($"Unable to parse '{dateString}' as DateTime.");
    }

    public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString(DateTimeFormat, CultureInfo.InvariantCulture));
    }
}

/// <summary>
/// 可空日期时间转换器，支持yyyy-MM-dd HH:mm:ss格式
/// </summary>
public class NullableDateTimeConverter : JsonConverter<DateTime?>
{
    private const string DateTimeFormat = "yyyy-MM-dd HH:mm:ss";

    public override DateTime? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        string dateString = reader.GetString();
        if (string.IsNullOrEmpty(dateString))
            return null;

        if (DateTime.TryParseExact(dateString, DateTimeFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime result))
            return result;

        // 如果解析失败，尝试使用默认解析
        if (DateTime.TryParse(dateString, out result))
            return result;

        throw new JsonException($"Unable to parse '{dateString}' as DateTime.");
    }

    public override void Write(Utf8JsonWriter writer, DateTime? value, JsonSerializerOptions options)
    {
        if (value.HasValue)
            writer.WriteStringValue(value.Value.ToString(DateTimeFormat, CultureInfo.InvariantCulture));
        else
            writer.WriteNullValue();
    }
}