using System.Globalization;

namespace raft.extensions;

internal static class DayOfWeekExtensions {
    public static string GetAbbreviatedDayName(this DayOfWeek day, CultureInfo culture) {
        culture ??= CultureInfo.InvariantCulture;
        return culture.DateTimeFormat
            .GetAbbreviatedDayName(day)
            .CapitalizeFirstLetter(culture);
    }

    public static DayOfWeek GetNextWeekDay(this DayOfWeek day) {
        var next = (int)day + 1;
        if (next > (int)DayOfWeek.Saturday) return DayOfWeek.Sunday;

        return (DayOfWeek)next;
    }

    private static string CapitalizeFirstLetter(this string? text, CultureInfo? culture = null) {
        if (text == null) return string.Empty;

        culture ??= CultureInfo.InvariantCulture;

        if (text.Length > 0 && char.IsLower(text[0]))
            text = string.Format(culture, "{0}{1}", char.ToUpper(text[0], culture), text.Substring(1));

        return text;
    }
}